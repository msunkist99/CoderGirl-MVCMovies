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
        static int nextId = 1;

        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        //static IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();

        public void Delete(int id)
        {
            directors.RemoveAll(m => m.Id == id);
        }

        public Director GetById(int id)
        {
            Director director = directors.SingleOrDefault(p => p.Id == id);
            return director;
        }

        public List<Director> GetDirectors()
        {
            /*  this will "seed" your list of directors
            Director director = new Director { FirstName = "Laura", LastName = "Rundquist", BirthDate = Convert.ToDateTime( "10/23/2000"), Nationality = "US" };
            Save(director);
            director = new Director { FirstName = "Barb", LastName = "Ruthier", BirthDate = Convert.ToDateTime("04/22/1964"), Nationality = "Crazy Town" };
            Save(director);
            director = new Director { FirstName = "Sue", LastName = "Wease", BirthDate = Convert.ToDateTime("06/10/1966"), Nationality = "Mexico" };
            Save(director);
            return directors.Select(d => SetMovies(d)).ToList();
            */

            return directors;
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
    }
}
