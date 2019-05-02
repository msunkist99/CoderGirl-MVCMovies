using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {

        private IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();

        /*
        private string htmlForm = @"
            <form method='post'>
                <input name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>                    
                </select>
                <button type='submit'>Rate it</button>
            </form>";
         */

        /// TODO: Done - Create a view Index. This view should list a table of all saved movie names with associated average rating
        /// TODO: Done - Be sure to include headers for Movie and Rating
        /// TODO: Done - Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {
            List<Movie> indexMovies = new List<Movie>();

            foreach (Movie movie in movieRatingRepository.Movies)
            {
                decimal averageRating = movieRatingRepository.GetAverageRatingByMovieName(movie.name);
                Movie indexMovie = new Movie();
                indexMovie.id = movie.id;
                indexMovie.name = movie.name;
                indexMovie.rating = Convert.ToInt16(averageRating);

                indexMovies.Add(indexMovie);
            }
            ViewBag.Movies = indexMovies;
            return View("Index");
        }

        // TODO: Done - Create a view MovieRating/Create and put the htmlForm there. Remember that html in a view should not be a string.
        // TODO: Done - Change the input tag for movie name to be a drop down which has a list of movies from the movie movieRatingRepository
        // TODO: Done - Change this method to return that view. 
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = MovieController.moviesDictionary;
            return View("Create");
        }

        // TODO: Done - Save the movie/rating in the MovieRatingRepository before redirecting to the Details page
        // TODO: Done - Redirect passing the values for the movieName and rating
        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            int id = movieRatingRepository.SaveRating(movieName, Convert.ToInt16(rating));
            return RedirectToAction(actionName: nameof(Details), routeValues: new {id });
        }

        // TODO: The Details method should take an int parameter which is the id of the movie/rating to display.
        // TODO: Done - Create a Details view which displays the formatted string with movie name and rating in an h2 tag. 
        // TODO: Done - The Details view should include a link to the MovieRating/Index page
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.MovieName = movieRatingRepository.GetMovieNameById(id);
            ViewBag.MovieRating = movieRatingRepository.GetRatingById(id);

            //ViewBag.MovieName = movieName;
            //ViewBag.AverageRating = rating;
            return View("Details");
            //return Content($"{movieName} has a rating of {rating}");
        }
    }
}