using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : IMovieRespository
    {
        static List<Movie> movies = new List<Movie>();
        static int nextId = 1;

        static IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public void Delete(int id)
        {
            movies.RemoveAll(m => m.Id == id);
        }

        public Movie GetById(int id)
        {
            //TODO: DONE  insert movieRatings
            Movie movie = movies.SingleOrDefault(m => m.Id == id);
            /*
            List<int> movieRatings = movieRatingRepository.GetMovieRatings()
                .Where(rating => rating.MovieId == id)
                .Select(rating => rating.Rating).ToList();

            movie.MovieRatings = movieRatings;
            */

            movie = SetMovieRatings(movie);
            movie = SetDirector(movie);

            movie.AverageRating = movieRatingRepository.GetAverageRating(movie.Id);
            movie.NumberOfRatings = movieRatingRepository.GetRatingCount(movie.Id);
            return movie;
        }

        public List<Movie> GetMovies()
        {
            //TODO:  FOREACH insert movieRatings
            /*
            foreach (Movie movie in movies)
            {
                List<int> movieRatings = movieRatingRepository.GetMovieRatings()
                        .Where(rating => rating.MovieId == movie.Id)
                        .Select(rating => rating.Rating).ToList();

                movie.MovieRatings = movieRatings;
            }
            */

            movies = movies.Select(movie => SetMovieRatings(movie)).ToList();
            movies = movies.Select(movie => SetDirector(movie)).ToList();
            movies = movies.Select(movie => SetAverageRating(movie)).ToList();
            movies = movies.Select(movie => SetRatingCount(movie)).ToList();

            return movies;
        }

        public void Update(Movie movie)
        {
            //there are many ways to accomplish this, this is just one possible way
            //the upside is that it is relatively simple, 
            //the (possible) downside is that it doesn't preserve the order in the list
            //as the AC doesn't specify, I am going with the simpler solution
            //once we start using the database this pattern will be simplified
            this.Delete(movie.Id);
            movies.Add(movie);
        }

        private Movie SetMovieRatings(Movie movie)
        {
            List<int> movieRatings = movieRatingRepository.GetMovieRatings()
                .Where(rating => rating.MovieId == movie.Id)
                .Select(rating => rating.Rating).ToList();

            movie.MovieRatings = movieRatings;

            return movie;
        }

        private Movie SetDirector(Movie movie)
        {
            Director director = directorRepository.GetById(movie.DirectorId);

            movie.DirectorName = director.LastFirstName;

            return movie;
        }

        private Movie SetAverageRating(Movie movie)
        {
            movie.AverageRating = movieRatingRepository.GetAverageRating(movie.Id);

            return movie;
        }

        private Movie SetRatingCount(Movie movie)
        {
            movie.NumberOfRatings = movieRatingRepository.GetRatingCount(movie.Id);

            return movie;
        }

        public int Save(Movie movie)
        {
            movie.Id = nextId++;
            movies.Add(movie);
            return movie.Id;
        }

    }
}
