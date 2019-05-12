using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();
        public static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();


        // TODO done - /movie/index view - link "Add a Movie" id="add-new_movie"
        // TODO done - /movie/index view - clicking on "Add a Movie" takes you to /movie/create
        // TODO done - on /movie/index view - table with columns in this order:  Name, Director, Year, Average Rating, Number of Ratings
        // TODO done - on /movie/index view - Edit and Delete links follow the entries in the table
        // TODO done - on /movie/index view - Director is formatted as last name, first name
        // TODO done - on /movie/index view - each row (<tr id="{movie id}") should display the correct information for each movie added.  if movie has not 
        //        been rated then Average Rating should be "none"
        // TODO done - on /movie/index view - Rate link next to each movie
        // TODO done - on /movie/index view - clicking Rate link takes user to /movierating/create_UsingModels2/{movieId} - movieId is for the specific movie
        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetMovies();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Directors = directorRepository.GetDirectors();
            return View();
        }

        // TODO - done - on /movie/create - choose a director for the movie from a dropdown - assumption is that a movie can have only one director
        // TODO - done - on /movie/create - director name in dropdown should be LastName, FirstName
        // TODO - done - on /movie/create - value returned by select should be the id of the director
        // TODO - on /movie/create - stretch goal - if a movie is added without a name display validation error
        // TODO - on /movie/create - stretch goal - if a validation error occurs none of the information entered should be erased
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieRepository.Save(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetById(id);
            ViewBag.Directors = directorRepository.GetDirectors();
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