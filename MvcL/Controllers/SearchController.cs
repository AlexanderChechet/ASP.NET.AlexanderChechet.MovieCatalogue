using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcL.Models;
using MvcL.Infrastructure.Mappers;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace MvcL.Controllers
{
    public class SearchController : Controller
    {
        private IMovieService movieService;

        public SearchController(IMovieService ms)
        {
            movieService = ms;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string SearchValue, bool Year, bool Producer, bool Description)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", new { value = SearchValue, year = Year, producer = Producer, description = Description });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Search(string value, bool year, bool producer, bool description)
        {
            var search = new SearchParams(year, producer, description);
            IEnumerable<MovieViewModel> result = movieService.SearchMovies(value, search).Select(x => x.ToMvcModel());
            return View(result);
        }
    }
}
