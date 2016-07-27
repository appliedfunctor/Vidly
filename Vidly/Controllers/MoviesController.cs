using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.ViewModel;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private readonly MovieRepository _movieRepository = new MovieRepository();

        [Route("movies")]
        public ViewResult Index()
        {
            var viewModel = new MoviesViewModel();
            viewModel.Movies = _movieRepository.GetMovies();
            return View(viewModel);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _movieRepository.GetMovie(id);

            if (movie != null){
                return View(movie);
            }

            return HttpNotFound();
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id > 0)
            {
                _movieRepository.UpdateMovie(movie);
            }
            else
            {
                _movieRepository.AddMovie(movie);
            }

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Delete(int id)
        {
            _movieRepository.RemoveMovie(id);
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {  
            var viewModel = new MoviesViewModel();
            viewModel.Genres = _movieRepository.GetGenres();
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MoviesViewModel();
            viewModel.Genres = _movieRepository.GetGenres();
            var movie = _movieRepository.GetMovie(id);
            return View("MovieForm", movie);
        }
    }
}