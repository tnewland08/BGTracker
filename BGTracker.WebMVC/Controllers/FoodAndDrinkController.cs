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
            var foodId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodAndDrinkService(foodId);
            var food = service.GetFoodAndDrinkList();

            return View(food);
        }

        // GET: FoodAndDrink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodAndDrink/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodAndDrinkCreate item)
        {
            if (!ModelState.IsValid) return View(item);

            var service = CreateFoodAndDrinkService();

            if (service.CreateFoodAndDrinkItem(item))
            {
                TempData["Save Result"] = "Item added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be saved.");

            return View(item);
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
            var item =
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

            return View(item);
        }

        // POST: FoodAndDrink/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodAndDrinkEdit item)
        {
            if (!ModelState.IsValid) return View(item);

            if (item.FoodId != id)
            {
                ModelState.AddModelError("", "Invalid Id");
                return View(item);
            }

            var service = CreateFoodAndDrinkService();

            if (service.UpdateFoodAndDrinkItem(item))
            {
                TempData["SaveResult"] = "Item was not updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be updated.");
            return View(item);
        }

        // GET: FoodAndDrink/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFoodAndDrinkService();
            var item = svc.GetFoodAndDrinkById(id);

            return View(item);
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
            var foodId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodAndDrinkService(foodId);
            return service;
        }
    }
}