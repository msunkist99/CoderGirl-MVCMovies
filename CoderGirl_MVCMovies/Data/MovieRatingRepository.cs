using CoderGirl_MVCMovies.Controllers;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        private static IMovieRatingRepository movieRatingRepository;

        public static List<Movie> movies = new List<Movie>();


        List<Movie> IMovieRatingRepository.Movies
        {
            get
            {
                if (movies == null)
                {
                    return movies = new List<Movie>();
                }
                else return movies;
            }
        }


        public static IMovieRatingRepository GetMovieRatingRepository()
        {
            //if (movieRatingRepository == null)
            //movieRatingRepository = new ??;
            // TODO: Done - new up your implementation class here

            if (movieRatingRepository == null)
            {
                movieRatingRepository = new MovieRatingRepository();
            }
            return movieRatingRepository;
        }

        public decimal GetAverageRatingByMovieName(string movieName)
        {
            var average = movies
                .Where(p => p.name == movieName)
                .GroupBy(q => q.name)
                .Select(r => r.Average(s => s.rating))
                .SingleOrDefault();

            return Convert.ToDecimal(average);
        }

        public List<int> GetIds()
        {
            return movies
                .Select(p => p.id).ToList();
        }

        public string GetMovieNameById(int id)
        {
            string movieName;
            return movieName = movies.Where(p => p.id == id).Select(p => p.name).SingleOrDefault();
        }

        public int GetRatingById(int id)
        {
            var rating =
                movies.Where(p => p.id == id)
                .Select(q => q.rating)
                .SingleOrDefault();

            return Convert.ToInt16(rating);
        }

        public int SaveRating(string movieName, int rating)
        {
            int nextIdToUse = 1;
            if (movies.Count != 0)
            {
                nextIdToUse = (movies.Max(p => p.id)) + 1;
            }

            Movie movie = new Movie();
            movie.id = nextIdToUse;
            movie.name = movieName;
            movie.rating = rating;

            //MovieController.moviesDictionary.Add(nextIdToUse, movie);
            movies.Add(movie);

            return nextIdToUse;
        }
    }
}
