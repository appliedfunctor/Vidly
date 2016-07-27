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
        public Movie Movie { get; set; } = new Movie();
        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}