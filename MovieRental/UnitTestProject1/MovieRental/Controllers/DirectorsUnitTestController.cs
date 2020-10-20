using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class DirectorsUnitTestController : Controller
    {
        [NonAction]
        public List<Directors> GetDirectorList()
        {
            return new List<Directors>
            {      new Directors
                {
                    Did = 18101,
                    Name = "Dean Winchester",
                    Gender = "Male",
                    
                },
                new Directors
                {
                    Did = 18102,
                    Name = "Wendy Scott",
                    Gender = "Female",
                },
            };
        }
        public IActionResult Index()
        {
            var directors = from s in GetDirectorList() select s;
            return View(directors);
        }

        public IActionResult Directors()
        {
            var directors = from e in GetDirectorList()
                            orderby e.Did
                            select e;
            return View(directors);
        }
    }
}