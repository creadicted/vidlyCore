using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;

namespace VidlyCore.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /Customers/Index
        public IActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        // GET: /Customers/Details/id
        [Route("Customers/Details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();

            }

            return View(customer);
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name  = "John Smith"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mary Williams"
                }
            };
        }
    }
}
