using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class CustomersUnitTestController : Controller
    {
        [NonAction]
        public List<Customers> GetCustomerList()
        {
            return new List<Customers>
            {      new Customers
                {
                    Cid = 18101,
                    Name = "John Smith",
                    Dob = DateTime.Today,
                    Email = "JohnS@gmail.com",
                    Phone = "021 123456",
                },
                new Customers
                {
                    Cid = 18102,
                    Name = "Peter Price",
                    Dob = DateTime.Today,
                    Email = "PeterP@gmail.com",
                    Phone = "020 123456",
                },
            };
        }

        public IActionResult Index()
        {
            var customers = from s in GetCustomerList() select s;
            return View(customers);
        }

        public IActionResult Customers()
        {
            var customers = from e in GetCustomerList()
                           orderby e.Cid
                           select e;
            return View(customers);
        }
    }
}

