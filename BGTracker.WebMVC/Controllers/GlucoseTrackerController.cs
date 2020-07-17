using BGTracker.Models.GlucoseTrackerModels;
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
    public class GlucoseTrackerController : Controller
    {
        // GET: GlucoseTracker/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GlucoseTrackerService(userId);
            var model = service.GetGlucoseTracker();

            return View(model);
        }

        // GET: GlucoseTracker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlucoseTracker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GlucoseTrackerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGlucoseTrackerService();

            if (service.CreateGlucoseTracker(model))
            {
                TempData["SaveResult"] = "Data has been added to your tracker";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your data could not be saved.");

            return View(model);
        }

        // GET: GlucoseTracker/Detail/{id}
        public ActionResult Detail(int id)
        {
            var svc = CreateGlucoseTrackerService();
            var model = svc.GetGlucoseTrackerById(id);

            return View(model);
        }

        // GET: GlucoseTracker/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateGlucoseTrackerService();
            var detail = service.GetGlucoseTrackerById(id);
            var model =
                new GlucoseTrackerEdit
                {
                    TrackerId = detail.TrackerId,
                    Date = detail.Date,
                    BloodGlucose = detail.BloodGlucose,
                    CorrectionDose = detail.CorrectionDose,
                    TotalCarbs = detail.TotalCarbs,
                    FoodDose = detail.FoodDose,
                    InsulinDose = detail.InsulinDose,
                    TimeOfDose = detail.TimeOfDose
                };

            return View(model);
        }

        // POST: GlucoseTracker/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GlucoseTrackerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TrackerId != id)
            {
                ModelState.AddModelError("", "Invalid Id");
                return View(model);
            }

            var service = CreateGlucoseTrackerService();

            if (service.UpdateGlucoseTracker(model))
            {
                TempData["SaveResult"] = "Your data was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your data could not be updated.");
            return View(model);
        }

        // GET: GlucoseTracker/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGlucoseTrackerService();
            var model = svc.GetGlucoseTrackerById(id);

            return View(model);
        }

        // POST: GlucoseTracker/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteData(int id)
        {
            var service = CreateGlucoseTrackerService();
            service.DeleteGlucoseTracker(id);
            TempData["SaveResult"] = "Your data was deleted.";

            return RedirectToAction("Index");
        }


        // Helper Methods
        public GlucoseTrackerService CreateGlucoseTrackerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GlucoseTrackerService(userId);
            return service;
        }
    }
}