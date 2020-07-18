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
            var model = service.GetUser();
            
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserService();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "Your profile was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Profile could not be created.");

            return View(model);
        }

        // GET: User/Detail/{id}
        public ActionResult Detail(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        //GET: User/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
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

            return View(model);
        }

        // POST: User/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserId != id)
            {
                ModelState.AddModelError("", "Id does not match User profile");
                return View(model);
            }

            var service = CreateUserService();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "Your profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View(model);
        }

        // GET: User/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
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