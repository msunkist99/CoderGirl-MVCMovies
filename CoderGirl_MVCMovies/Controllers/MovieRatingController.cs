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
        private IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRespository movieRespository = RepositoryFactory.GetMovieRepository();

       public IActionResult Index()
        {
            List<MovieRating> movieRatings = ratingRepository.GetMovieRatings();
            return View(movieRatings);
        }

        // TODO - /movierating/create/{movieId} - view should be populated with readonly input for the movie name
        // TODO - /movierating/create/{movieId} - user should be able to select a rating from a dropdown list
        // TODO - /movierating/create/{movieId} - clicking on submit button redirect to movie/index view
        // TODO - try creating another get/create method that takes the movieId input parameter
        // TODO - try creating another movierating/create view for these changes
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MovieNames = movieRespository.GetMovies().Select(m => m.Name).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            ratingRepository.Save(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = ratingRepository.GetById(id);
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            ratingRepository.Update(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ratingRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}