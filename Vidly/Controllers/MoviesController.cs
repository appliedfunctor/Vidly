using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        [Route("movies")]
        public ViewResult Index()
        {
            var viewModel = new MoviesViewModel();
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year = {year}, month = {month}");
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var viewModel = new MoviesViewModel();
            var movie = viewModel.GetMovie(id);

            if (movie != null){
                return View(movie);
            }

            return HttpNotFound();
        }

        // GET: Movies
        [Route("movies/random")]
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};
            var customers = new List<Customer>
            {
                //new Customer {Name = "Customer 1"},
                //new Customer {Name = "Customer 2"},
                //new Customer {Name = "Customer 3"},
                //new Customer {Name = "Customer 4"},
               // new Customer {Name = "Customer 5"}
            };

            var vm = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            
            };

            return View(vm);
        }
    }
}