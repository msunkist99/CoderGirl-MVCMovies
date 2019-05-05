using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRespository movieRespository = RepositoryFactory.GetMovieRepository();

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

       public IActionResult Index()
        {
            return View(movieRatingRepository.GetMovieRatings());
        }

        [HttpGet]
        public IActionResult Create()
        {
            //List<Movie> movies = movieRespository.GetMovies();

            ViewBag.MovieNames = movieRespository.GetMovies().Select(m => m.Name).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            //return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });


            /*MovieRating movieRating = new MovieRating();
            movieRating.Movie = movieName;
            movieRating.Rating = rating;
            movieRatingRepository.Save(movieRating);

            return RedirectToAction(actionName: nameof(Index));
            */

            movieRatingRepository.Save(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.Movie = movieName;
            ViewBag.Rating = rating;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(movieRatingRepository.GetById(id));
        }

        [HttpPost]
        //public IActionResult Edit(int id, MovieRating movie)
        public IActionResult Edit(int id, MovieRating movie)
        { 
            //movie.Id = id;
            movieRatingRepository.Update(movie);

            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRatingRepository.Delete(id);

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}