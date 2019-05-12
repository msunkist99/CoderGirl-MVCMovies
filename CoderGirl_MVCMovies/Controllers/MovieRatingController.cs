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
        private IMovieRespository movieRespository = RepositoryFactory.GetMovieRepository();

       public IActionResult Index()
        {
            List<MovieRating> movieRatings = movieRatingRepository.GetMovieRatings();
            return View(movieRatings);
        }

        // TODO - done - /movierating/create/{movieId} - view should be populated with readonly input for the movie name
        // TODO - done - /movierating/create/{movieId} - user should be able to select a rating from a dropdown list
        // TODO - done - /movierating/create/{movieId} - clicking on submit button redirect to movie/index view
        // TODO - done - CreateUsingModels2 - try creating another get/create method that takes the movieId input parameter
        // TODO - done try creating another movierating/create view for these changes
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MovieNames = movieRespository.GetMovies().Select(m => m.Name).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            movieRatingRepository.Save(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateUsingModels2(int movieId)
        {
            ViewBag.Movie = movieRespository.GetById(movieId);
            return View();
        }

        [HttpPost]
        public IActionResult CreateUsingModels2(MovieRating movieRating)
        {
            movieRatingRepository.Save(movieRating);
            return RedirectToAction(controllerName: nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = movieRatingRepository.GetById(id);
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            movieRatingRepository.Update(movieRating);
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