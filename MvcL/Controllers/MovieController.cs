using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using MvcL.Infrastructure.Mappers;
using MvcL.Models;
using System.IO;
using System.Collections;

namespace MvcL.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService movieService;
        private IMarkService markService;
        private IUserService userService;
        private IFavoriteService favoriteService;

        public MovieController(IMovieService ms, IMarkService marks, IUserService us, IFavoriteService fs)
        {
            movieService = ms;
            markService = marks;
            userService = us;
            favoriteService = fs;
            var scale = new SelectList(
                new int[] { 1, 2, 3, 4, 5 }.Select(
                    x => new SelectListItem
                    {
                        Value = x.ToString(),
                        Text = x.ToString()
                    }),
                "value",
                "text");
            ViewBag.MarkScale = scale;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movies = movieService.GetAllMovies().Select(x => x.ToMvcModel());
            return View(movies);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                movieService.AddMovie(movie.ToBllEntity());
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Edit(int id)
        {
            MovieViewModel movie = movieService.GetMovie(id).ToMvcModel();
            return View(movie);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Edit(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                movieService.UpdateMovie(movie.ToBllEntity());
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(int id)
        {
            MovieViewModel movie = movieService.GetMovie(id).ToMvcModel();
            return View(movie);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                movieService.DeleteMovie(movie.ToBllEntity());
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public ActionResult Details(int id)
        { 
            MovieViewModel movie = movieService.GetMovie(id).ToMvcModel();
            var user = userService.GetUserByName(User.Identity.Name);
            var currentMark = markService.GetUserMovieMark(user.Id, id);
            ViewBag.DefaultMark = currentMark.Mark == 0 ? "Select mark" : currentMark.Mark.ToString();

            return View(movie);
        }

        [HttpPost]
        public ActionResult Details(MovieViewModel movie, dynamic marks)
        {
            movie = movieService.GetMovie(movie.Id).ToMvcModel();
            int mark = 0;
            string parse = (marks as String[])[0];
            int.TryParse(parse, out mark);
            var user = userService.GetUserByName(User.Identity.Name);
            ProcessMark(mark, movie.Id, user.Id);
            ProcessAverageMark(movie.Id);
            var currentMark = markService.GetUserMovieMark(user.Id, movie.Id);
            movie = movieService.GetMovie(movie.Id).ToMvcModel();
            ViewBag.DefaultMark = currentMark.Mark == 0 ? "Select mark" : currentMark.Mark.ToString();
            return View(movie);
        }

        public ActionResult AddFavorite(int id)
        {
            
        }

        private void ProcessMark(int mark, int movieId, int userId)
        {
            var markEntity = markService.GetUserMovieMark(userId, movieId);
            if (markEntity.Mark == 0)
            {
                markService.AddUserMovieMark(new MarkEntity()
                    {
                        Mark = mark,
                        MovieId = movieId,
                        UserId = userId
                    });
            }
            else
                if (markEntity.Mark != mark)
                {
                    markService.UpdateUserMovieMark(new MarkEntity()
                        {
                            Id = markEntity.Id,
                            Mark = mark,
                            MovieId = movieId,
                            UserId = userId
                        });
                }
        }

        private void ProcessAverageMark(int movieId)
        {
            var entity = markService.GetMovieMarks(movieId);
            var movie = movieService.GetMovie(movieId);
            int summa = 0;
            foreach (var item in entity.Marks)
            {
                summa += item.Value;
            }
            float average = summa / (float)entity.Marks.Count;
            movie.Mark = average;
            movieService.UpdateMovie(movie);
        }
    }
}
