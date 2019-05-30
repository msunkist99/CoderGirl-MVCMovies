using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        static IModelRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IModelRepository directorRepository = RepositoryFactory.GetDirectorRepository();
        // models comes from the BaseRepository which has access method of protected


        //  override BaseRepository
        public override IModel GetById(int id)
        {
            // cast returning model to Movie type
            Movie movie = (Movie) base.GetById(id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);
            movie = SetRatingAverage(movie);
            movie = SetRatingCount(movie);

            // Movie is an IModel
            return movie;
            // code calling this method must cast as Movie because this method returns IModel type, not Movie type
        }

        // override BaseRepository
        public override List<IModel> GetModels()
        {
            List<Movie> movies = base.GetModels().Cast<Movie>().ToList();

            movies.Select(movie => SetMovieRatings(movie))
                         .Select(movie => SetDirectorName(movie))
                         .ToList();

            return movies.Cast<IModel>().ToList();
        }

        // this is only in the child not in BaseRepository
        private Movie SetMovieRatings(Movie movie)
        {
             movie.Ratings  = movieRatingRepository.GetModels()
                                              .Cast<MovieRating>()
                                              .Where(rating => rating.MovieId == movie.Id)
                                              .Select(rating => rating.Rating)
                                              .ToList();

            return movie;
        }

        // this is only in the child not in BaseRepository
        private Movie SetDirectorName(Movie movie)
        {
            Director director = (Director) directorRepository.GetById(movie.DirectorId);
            movie.DirectorName = director.FullName;

            return movie;
        }

        //  SetRatingAverage and SetRatingCount are here in the MovieRepository
        //  instead of in the MovieRatingRepository
        //  because you cannot add these methods to MovieRatingRepository
        //  and then create a movieRatingRepository that is a type - IModelRepository
        //  because these methods are not in IModelRepository
        //  static IModelRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        private Movie SetRatingAverage(Movie movie)
        {
            List<MovieRating> movieRatings = RepositoryFactory.GetMovieRatingRepository()
                                                              .GetModels()
                                                              .Cast<MovieRating>()
                                                              .ToList();

            var average = movieRatings.Where(p => p.MovieId == movie.Id)
                                      .GroupBy(p => p.MovieId)
                                      .Select(p => p.Average(q => q.Rating))
                                      .SingleOrDefault();

            movie.RatingAverage = Convert.ToDecimal(average);

            return movie;
        }

        private Movie SetRatingCount(Movie movie)
        {
            List<MovieRating> movieRatings = RepositoryFactory.GetMovieRatingRepository()
                                                  .GetModels()
                                                  .Cast<MovieRating>()
                                                  .ToList();

            var count = movieRatings.Where(p => p.MovieId == movie.Id)
                                    .Count();

            movie.RatingCount = Convert.ToInt16(count);

            return movie;
        }
    }
}
