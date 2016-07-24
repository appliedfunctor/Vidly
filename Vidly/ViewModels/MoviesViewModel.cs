using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public List<Movie> Movies = new List<Movie>();

        public MoviesViewModel()
        {
            Movies.Add(new Movie {Id = 0, Name = "Star Wars"});
            Movies.Add(new Movie {Id = 1, Name = "Jaws"});
        }

        public Movie GetMovie(int id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }
    }
}