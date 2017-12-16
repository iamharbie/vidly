using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Apis
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalsDto rentalsDto)
        {
            var customer = _context.Customers.Single(c => c.Id == rentalsDto.CustomerId);

            var movies = _context.Movies.Where(m => rentalsDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("Movie not available");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    
                    DateRented = DateTime.Now,
                    Movie = movie,
                    Customer = customer
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
