using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        List<Movie> movie_list = new List<Movie>
            {
                new Movie { id=1, Name="Debbie Does Dallas" },
                new Movie { id=2, Name="Catholic High School Girls in Trouble"},
                new Movie { id=3, Name="Breakfast In Bed"}
            };


        [Route("Movies/List")]
        [Route("Movies/Index")]
        [Route("Movies")]
        public ActionResult List()
        {
            return View(movie_list);
        }

        [Route("Movies/Details/{movieID}")]
        public ActionResult Details(int movieID)
        {
            var mymovie = movie_list.Where(m => m.id == movieID).FirstOrDefault();

            return View(mymovie);
        }










        // GET: Movies
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        [Route("Movies/Random")]
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                movie = movie,
                customer = customers
            };

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            //return new EmptyResult();
            //return HttpNotFound();
            //return Content("Hello World");
            ViewBag.MyTest = "MyTest Fired";
            return View(viewModel);
            //return View(movie);


            /*
ViewResult
PartialViewResult
ContentResult
RedirectResult
RedirecToRouteResult
JSonResult
FileResult
HttpNotFoundResult
EmptyResult (Void)
             */
        }



        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        //public ActionResult Index(int pageIndex= 1, string sortBy = "name")
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
         * */





        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "\\" + month);
        }
    }
}