// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace VidlyCore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using VidlyCore.Data;
    using VidlyCore.Models;
    using VidlyCore.ViewModel;

    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Function to load a list of movies.
        /// </summary>
        /// <returns>The View.</returns>
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        /// <summary>
        /// Function to display a form to create a new Movie.
        /// </summary>
        /// <returns>The View.</returns>
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        /// <summary>
        /// View Result from HttpPost that saves movie data to a new or existing Movie.
        /// </summary>
        /// <param name="movie">The movie send from the Form.</param>
        /// <returns>A Redirect to the Movie Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.Genre = movie.Genre;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Movies");
        }

        /// <summary>
        /// Function to load a Movie by Id and present an edit view.
        /// </summary>
        /// <param name="id">The Movies Id</param>
        /// <returns>ViewResult that shows a view to edit a specific Movie.</returns>
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

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

        [Route("Movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("{0}/{1}", year, month));
        }
    }
}
