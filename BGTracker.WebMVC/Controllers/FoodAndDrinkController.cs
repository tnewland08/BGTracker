using BGTracker.Models.FoodAndDrinkModels;
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
    public class FoodAndDrinkController : Controller
    {
        // GET: FoodAndDrink/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodAndDrinkService(userId);
            var model = service.GetFoodAndDrinkList();

            return View(model);
        }

        // GET: FoodAndDrink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodAndDrink/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodAndDrinkCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFoodAndDrinkService();

            if (service.CreateFoodAndDrinkItem(model))
            {
                TempData["SaveResult"] = "Item added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be saved.");

            return View(model);
        }

        // GET: FoodAndDrink/Detail/{id}
        public ActionResult Detail(int id)
        {
            var svc = CreateFoodAndDrinkService();
            var item = svc.GetFoodAndDrinkById(id);

            return View(item);
        }

        // GET: FoodAndDrink/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateFoodAndDrinkService();
            var detail = service.GetFoodAndDrinkById(id);
            var model =
                new FoodAndDrinkEdit
                {
                    FoodId = detail.FoodId,
                    Item = detail.Item,
                    IsFood = detail.IsFood,
                    IsDrink = detail.IsDrink,
                    CarbsPerServing = detail.CarbsPerServing,
                    ServingSize = detail.ServingSize,
                    FastActingCarb = detail.FastActingCarb,
                    Favorite = detail.Favorite
                };

            return View(model);
        }

        // POST: FoodAndDrink/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodAndDrinkEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FoodId != id)
            {
                ModelState.AddModelError("", "Invalid Id");
                return View(model);
            }

            var service = CreateFoodAndDrinkService();

            if (service.UpdateFoodAndDrinkItem(model))
            {
                TempData["SaveResult"] = "Item was not updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be updated.");
            return View(model);
        }

        // GET: FoodAndDrink/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFoodAndDrinkService();
            var model = svc.GetFoodAndDrinkById(id);

            return View(model);
        }

        // POST: FoodAndDrink/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            var service = CreateFoodAndDrinkService();
            service.DeleteFoodAndDrinkItem(id);
            TempData["SaveResult"] = "Item was delete.";

            return RedirectToAction("Index");
        }


        // Helper Methods
        public FoodAndDrinkService CreateFoodAndDrinkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodAndDrinkService(userId);
            return service;
        }
    }
}