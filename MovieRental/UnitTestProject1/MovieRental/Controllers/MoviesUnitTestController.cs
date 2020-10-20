using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class MoviesUnitTestController : Controller
    {
        [NonAction]
        public List<Movies> GetMovieList()
        {
            return new List<Movies>
            {
                new Movies
                {
                    MovieId = 18101,
                    Cid = 18101,
                    DirectorId = 18101,
                    Title = "Wellington",
                    ReleaseYear = 1900,
                    
                },
                new Movies
                {
                    MovieId = 18102,
                    Cid = 18102,
                    DirectorId = 18101,
                    Title = "Porirua",
                    ReleaseYear = 2020,
                },
            };
        }
        public IActionResult Index()
        {
            var movies = from s in GetMovieList() select s;
            return View(movies);
        }

        public IActionResult Movies()
        {
            var movies = from e in GetMovieList()
                            orderby e.MovieId
                         select e;
            return View(movies);
        }
    }
}