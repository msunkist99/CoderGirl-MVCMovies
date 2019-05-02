using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static Dictionary<int, string> moviesDictionary = new Dictionary<int, string>();

        private static int nextIdToUse = 1; 

        public IActionResult Index()
        {
            ViewBag.MoviesDictionary = moviesDictionary;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movie)
        {
            moviesDictionary.Add(nextIdToUse, movie);
            nextIdToUse++;
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}