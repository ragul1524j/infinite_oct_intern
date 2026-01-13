using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesMvcCodeFirst.Models;
using MoviesMvcCodeFirst.Repository;

namespace MoviesMvcCodeFirst.Controllers
{
    public class MoviesController : Controller
    {
        MovieRepository repo = new MovieRepository();
        // GET: Movies
        public ActionResult Index()
        {
            var movies = repo.GetAllMovies();
            return View(movies);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.AddMovie(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = repo.GetMovieById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateMovie(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetMovieById(id);
            return View(movie);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteMovie(id);
            repo.Save();
            return RedirectToAction("Index");
        }


        // return movies by year
        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetMoviesByYear(year);
            return View(movies);
        }


        //return movies by director
        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetMoviesByDirector(directorName);
            return View(movies);
        }
    }
}