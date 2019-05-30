﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        static IModelRepository movieRepository = RepositoryFactory.GetMovieRepository();
        static IModelRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<MovieIndexViewModel> movieIndexViewModels = MovieIndexViewModel.GetMovieIndexViewModel();
            return View(movieIndexViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            MovieCreateViewModel movie = MovieCreateViewModel.GetMovieCreateViewModel();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movie)
        {
            if (String.IsNullOrWhiteSpace(movie.Name))
            {
                ModelState.AddModelError("Name", "Name must be included");
            }
            if(movie.Year < 1888 || movie.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Not a valid year");
            }

            if(ModelState.ErrorCount > 0)
            {
                movie.Directors = directorRepository.GetModels()
                                                      .Cast<Director>()
                                                      .ToList();
                return View(movie);
            }

            //movieRepository.Save(movie);
            movie.Persist();
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieEditViewModel movie = MovieEditViewModel.GetMovieEditViewModel(id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            //since id is not part of the edit form, it isn't included in the model, thus it needs to be set from the route value
            //there are alternative patterns for doing this - for one, you could include the id in the form but make it hidden
            //feel free to experiment - the tests wont' care as long as you preserve the id correctly in some manner
            movie.Id = id; 
            movieRepository.Update(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}