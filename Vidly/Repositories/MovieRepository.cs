using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Libraries;
using Vidly.Models;

namespace Vidly.Repositories
{
    public class MovieRepository : IDisposable
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void RemoveMovie(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == id);
            _context.Movies.Remove(movieInDb);
        }

        public void UpdateMovie(Movie movie, string[] allowedProps = null)
        {
            var repository = new Repository();
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            movieInDb = repository.PopulateDbObjectFromWeb(movie, movieInDb);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
                _context?.Dispose();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}