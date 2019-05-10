using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        // TODO - create a Director model with properties - FirstName, LastName, BirthDate(datetime), Nationality, Id - consider a formatted LastFirstName property
        // TODO - /director/index view - add a "Add a Director" link - (id="add-new-director") which takes user to /director/create
        // TODO - /director/index view - table with columns - Name, Birth Date, Nationality.
        // TODO - /director/index view - Name should be formatted as LastName, FirstName
        // TODO - /director/index view - <tr id="{director id}">
        public IActionResult Index()
        {
            return View();
        }

        // TODO - /director/create view - input values for First Name, Last Name, Birth Date, Nationality
        // TODO - /director/create view - button "Add Director" - redirect to /director/index
        // TODO - stretch goal - if no last name is entered, return director/create view with validation error message
        public IActionResult Create()
        {
            return View();
        }
    }
}