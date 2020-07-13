using BGTracker.Models.UserModels;
using BGTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BGTracker.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            var user = service.GetUser();
            
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate user)
        {
            if (!ModelState.IsValid) return View(user);

            var service = CreateUserService();

            if (service.CreateUser(user))
            {
                TempData["SaveResult"] = "Your profile was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Profile could not be created.");

            return View(user);
        }

        // GET: User/Detail/{id}
        public ActionResult Detail(int id)
        {
            var svc = CreateUserService();
            var user = svc.GetUserById(id);

            return View(user);
        }

        //GET: User/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var user =
                new UserEdit
                {
                    UserId = detail.UserId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Birthday = detail.Birthday,
                    Diagnosed = detail.Diagnosed,
                    TypeOne = detail.TypeOne,
                    TypeTwo = detail.TypeTwo
                };

            return View(user);
        }

        // POST: User/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit user)
        {
            if (!ModelState.IsValid) return View(user);

            if (user.UserId != id)
            {
                ModelState.AddModelError("", "Id does not match User profile");
                return View(user);
            }

            var service = CreateUserService();

            if (service.UpdateUser(user))
            {
                TempData["SaveResult"] = "Your profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(user);
        }

        // GET: User/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserService();
            var user = svc.GetUserById(id);

            return View(user);
        }

        // POST: User/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserProfile(int id)
        {
            var service = CreateUserService();
            service.DeleteUser(id);
            TempData["SaveResult"] = "User profile was deleted.";

            return RedirectToAction("Index");
        }


        // Helper Methods
        public UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
}