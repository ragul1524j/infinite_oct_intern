using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviesMvcCodeFirst.Models;

namespace MoviesMvcCodeFirst.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        IEnumerable<Movie> GetMoviesByYear(int year);
        IEnumerable<Movie> GetMoviesByDirector(string directorName);
        void Save();
    }

}