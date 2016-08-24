using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Core;
using VidlyCore.Models;
using VidlyCore.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace VidlyCore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Index/
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        // GET: Movies/Details/
        [Route("Movies/Details/{id}")]
        public IActionResult Details(int id)
        {
            var movies = GetMovies().SingleOrDefault(c => c.Id == id);
            if (movies == null)
            {
                return NotFound();

            }

            return View(movies);
        }

        // GET: Movies/Random/
        public ViewResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shreck"
            };

            var customers = new List<Customer>
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

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Movies/Edit/
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("Movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("{0}/{1}", year, month));
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Shreck"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Wall-e"
                }
            };
        }
    }
}
