using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movie
{
    public class MovieCreateViewModel
    {
        // let this be a factory method instead of a constructor
        public static MovieCreateViewModel GetMovieCreateViewModel()
        {
            MovieCreateViewModel movieCreateViewModel = new MovieCreateViewModel();

            movieCreateViewModel.Directors = RepositoryFactory.GetDirectorRepository()
                                                        .GetModels()
                                                        .Cast<Director>()
                                                        .ToList();

            // so we created an empty MovieCreateViewModel except we did include a list of directors
            return movieCreateViewModel;
        }

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

            RepositoryFactory.GetMovieRepository().Save(movie);
        }
    }
}
