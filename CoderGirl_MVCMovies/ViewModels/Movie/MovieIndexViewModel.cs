using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movie
{
    public class MovieIndexViewModel
    {
        public static List<MovieIndexViewModel> GetMovieIndexViewModel()
        {
            List<Models.Movie> movies = RepositoryFactory.GetMovieRepository()
                                                         .GetModels()
                                                         .Cast<Models.Movie>()
                                                         .ToList();

            List<MovieIndexViewModel> movieIndexViewModels = new List<MovieIndexViewModel>();
            foreach (var movie in movies)
            {
                MovieIndexViewModel movieViewModel = new MovieIndexViewModel();

                movieViewModel.Id = movie.Id;
                movieViewModel.Name = movie.Name;
                movieViewModel.Year = movie.Year;
                movieViewModel.DirectorName = movie.DirectorName;
                movieViewModel.RatingsAverage = movie.RatingAverage;
                movieViewModel.RatingsCount = movie.RatingCount;

                movieIndexViewModels.Add(movieViewModel);
            }

            return movieIndexViewModels;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public int RatingsCount { get; set; }
        public decimal RatingsAverage { get; set; }
    }
}
