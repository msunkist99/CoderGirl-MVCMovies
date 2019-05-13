using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        public static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        // TODO - done - create a Director model with properties - FirstName, LastName, BirthDate(datetime), Nationality, Id - consider a formatted LastFirstName property
        // TODO - done - /director/index view - add a "Add a Director" link - (id="add-new-director") which takes user to /director/create
        // TODO - done - /director/index view - table with columns - Name, Birth Date, Nationality.
        // TODO - done - /director/index view - Name should be formatted as LastName, FirstName
        // TODO - done - /director/index view - <tr id="{director id}">
        [HttpGet]
        public IActionResult Index()
        {
            List<Director> directors = directorRepository.GetDirectors();
            return View(directors);
        }

        // TODO - done - /director/create view - input values for First Name, Last Name, Birth Date, Nationality
        // TODO - done - /director/create view - button "Add Director" - redirect to /director/index
        // TODO - stretch goal - if no last name is entered, return director/create view with validation error message
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            directorRepository.Save(director);
            return RedirectToAction(controllerName: nameof(Director), actionName: nameof(Index));
        }
    }
}