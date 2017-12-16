using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            //var movies = GetMovies();
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                   return View("List");

            return View("ReadOnlyList");
        }

        // GET: Movies/Details
        public ActionResult Details(int id)
        {
           // var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie==null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                
                Genre =genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList(),
                   
                };

                return View("MovieForm", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrSave(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberLeftInStock = movie.NumberLeftInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleasedDate = movie.ReleasedDate;

            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        /*
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie(){Id=1, Name="Shrek!"},
                new Movie(){Id=2, Name="Wall-e" }

            };
        }
        */
    }
}