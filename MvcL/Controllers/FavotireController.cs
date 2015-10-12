using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using MvcL.Models;
using MvcL.Infrastructure.Mappers;

namespace MvcL.Controllers
{
    public class FavotireController : Controller
    {
        private IUserService userService;
        private IFavoriteService favoriteService;
        private IMovieService movieService;

        public FavotireController(IUserService us, IFavoriteService fs, IMovieService ms)
        {
            userService = us;
            favoriteService = fs;
            movieService = ms;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = userService.GetUserByName(User.Identity.Name);
            var movieArray = favoriteService.GetFavorites(user.Id).Movies;
            List<MovieViewModel> movies = new List<MovieViewModel>();
            for (int i = 0; i < movieArray.Length; i++)
            {
                movies.Add(movieService.GetMovie(movieArray[i]).ToMvcModel());
            }
            return View(movies);
        }

        public ActionResult Add(int id)
        {
            var user = userService.GetUserByName(User.Identity.Name);
            favoriteService.AddFavorite(new FavoriteEntity()
                {
                    UserId = user.Id,
                    MovieId = id
                });
            return RedirectToAction("Index");
        }
    }
}
