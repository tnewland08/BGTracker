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
            var trackerId = Guid.Parse(User.Identity.GetUserId());
            var service = new GlucoseTrackerService(trackerId);
            var tracker = service.GetGlucoseTracker();

            return View(tracker);
        }

        // GET: GlucoseTracker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlucoseTracker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GlucoseTrackerCreate glucose)
        {
            if (!ModelState.IsValid) return View(glucose);

            var service = CreateGlucoseTrackerService();

            if (service.CreateGlucoseTracker(glucose))
            {
                TempData["SaveResult"] = "Data has been added to your tracker";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your data could not be saved.");

            return View(glucose);
        }

        // GET: GlucoseTracker/Detail/{id}
        public ActionResult Detail(int id)
        {
            var svc = CreateGlucoseTrackerService();
            var tracker = svc.GetGlucoseTrackerById(id);

            return View(tracker);
        }

        // GET: GlucoseTracker/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateGlucoseTrackerService();
            var detail = service.GetGlucoseTrackerById(id);
            var tracker =
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

            return View(tracker);
        }

        // POST: GlucoseTracker/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GlucoseTrackerEdit tracker)
        {
            if (!ModelState.IsValid) return View(tracker);

            if (tracker.TrackerId != id)
            {
                ModelState.AddModelError("", "Invalid Id");
                return View(tracker);
            }

            var service = CreateGlucoseTrackerService();

            if (service.UpdateGlucoseTracker(tracker))
            {
                TempData["SaveResult"] = "Your data was not updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your data could not be updated.");
            return View(tracker);
        }

        // GET: GlucoseTracker/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGlucoseTrackerService();
            var tracker = svc.GetGlucoseTrackerById(id);

            return View(tracker);
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
            var trackerId = Guid.Parse(User.Identity.GetUserId());
            var service = new GlucoseTrackerService(trackerId);
            return service;
        }
    }
}