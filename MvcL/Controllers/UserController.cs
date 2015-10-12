using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcL.Infrastructure.Mappers;
using MvcL.Models;

namespace MvcL.Controllers
{
    [Authorize(Roles = "Admin, Moderator, User")]
    public class UserController : Controller
    {
        private IUserService userService;
        private IRoleService roleService;

        public UserController(IUserService us, IRoleService rs)
        {
            userService = us;
            roleService = rs;
            List<RoleEntity> tempRoles = roleService.GetAllRoles().ToList();
            tempRoles.Sort((x, y) => { return x.Id - y.Id; });
            tempRoles.RemoveAt(0);
            SelectList roles = new SelectList(tempRoles, "Id", "RoleName");
            var roleArray = new string[tempRoles.Count + 2];
            foreach (var role in tempRoles)
            {
                roleArray[role.Id] = role.RoleName;
            }
            ViewBag.Roles = roles;
            ViewBag.RolesArray = roleArray;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = userService.GetAllUsers().Select(x => x.ToMvcModel());
            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user.ToBllEntity());
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            UserViewModel user = userService.GetUser(id).ToMvcModel();            
            
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userService.UpdateUser(user.ToBllEntity());
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            UserViewModel user = userService.GetUser(id).ToMvcModel();
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                userService.DeleteUser(user.ToBllEntity());
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }

    
}