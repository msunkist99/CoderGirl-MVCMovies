using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        private static List<MovieRating> movieRatings = new List<MovieRating>();
        private static int nextId = 1;

        public void Delete(int id)
        {
            movieRatings.RemoveAll(r => r.Id == id);
        }

        public decimal GetAverageRating(int movieId)
        {
            var average = movieRatings
                .Where(p => p.MovieId == movieId)
                .GroupBy(p => p.MovieId)
                .Select(p => p.Average(q => q.Rating))
                .SingleOrDefault();

            return Convert.ToDecimal(average);
        }

        public MovieRating GetById(int id)
        {
            return movieRatings.SingleOrDefault(r => r.Id == id);
        }

        public List<MovieRating> GetMovieRatings()
        {
            return movieRatings;
        }

        public int GetRatingCount(int movieId)
        {
            var count = movieRatings
                .Where(p => p.MovieId == movieId)
                .Count();

            return Convert.ToInt16(count);
        }

        public int Save(MovieRating movieRating)
        {
            movieRating.Id = nextId++;
            movieRatings.Add(movieRating);
            return movieRating.Id;
        }

        public void Update(MovieRating movieRating)
        {
            this.Delete(movieRating.Id);
            movieRatings.Add(movieRating);
        }
    }
}
