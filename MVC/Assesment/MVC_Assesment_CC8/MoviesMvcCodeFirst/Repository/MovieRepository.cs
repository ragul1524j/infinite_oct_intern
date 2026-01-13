using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviesMvcCodeFirst.Models;

namespace MoviesMvcCodeFirst.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesDbContext db = new MoviesDbContext();
        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return db.Movies.Find(id);
        }

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
            }
        }

        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            return db.Movies .Where(m => m.DateOfRelease.Year == year) .ToList();
        }

        public IEnumerable<Movie> GetMoviesByDirector(string directorName)
        {
            return db.Movies .Where(m => m.DirectorName == directorName) .ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}