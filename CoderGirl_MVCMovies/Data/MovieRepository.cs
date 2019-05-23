using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        static IModelRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IModelRepository directorRepository = RepositoryFactory.GetDirectorRepository();
        // models comes from the BaseRepository which has access method of protected


        //  override BaseRepository
        public override IModel GetById(int id)
        {
            // cast returning model to Movie type
            Movie movie = (Movie) base.GetById(id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);

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
             movie.Ratings  = ratingRepository.GetModels()
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
    }
}
