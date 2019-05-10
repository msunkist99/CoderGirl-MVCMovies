using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class DirectorRepository : IDirectorRepository
    {
        static List<Director> directors = new List<Director>();
        static int nextId = 0;

        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        static IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();


        public void Delete(int id)
        {
            directors.RemoveAll(m => m.Id == id);
        }

        public Director GetById(int id)
        {
            Director director = directors.SingleOrDefault(p => p.Id == id);

            director = SetMovies(director);

            return director;
        }

        public List<Director> GetDirectors()
        {
            return directors.Select(director => SetMovies(director)).ToList();
        }

        public int Save(Director director)
        {
            director.Id = nextId++;
            directors.Add(director);
            return director.Id;
        }

        public void Update(Director director)
        {
            this.Delete(director.Id);
            directors.Add(director);
        }

        private Director SetMovies(Director director)
        {
            List<Movie> movies = movieRepository.GetMovies()
                .Where(id => id.DirectorId == director.Id)
                .ToList();

            director.Movies = movies;

            return director;
        }


    }
}
