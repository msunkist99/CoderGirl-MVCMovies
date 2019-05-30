using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movie
{
    public class MovieEditViewModel

    {
        // let this be a factory method instead of a constructor
        public static MovieEditViewModel GetMovieEditViewModel(int id)
        {
            MovieEditViewModel movieEditViewModel = new MovieEditViewModel();

            IModel model = RepositoryFactory.GetMovieRepository().GetById(id);
            Models.Movie movie = (Models.Movie)model;

            movieEditViewModel.Id = movie.Id;
            movieEditViewModel.Name = movie.Name;
            movieEditViewModel.Year = movie.Year;

            movieEditViewModel.Directors = RepositoryFactory.GetDirectorRepository()
                                                        .GetModels()
                                                        .Cast<Director>()
                                                        .ToList();

            // so we created an empty MovieEditViewModel except we did include a list of directors
            return movieEditViewModel;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public List<Director> Directors { get; set; }
        public int Year { get; set; }

        public void Persist()
        {
            Models.Movie movie = new Models.Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                Year = this.Year                
            };

            IModel model = RepositoryFactory.GetDirectorRepository().GetById(this.DirectorId);
            Models.Director director = (Models.Director)model;
            movie.DirectorName = director.FullName;

            RepositoryFactory.GetMovieRepository().Update(movie);
        }
    }

}

