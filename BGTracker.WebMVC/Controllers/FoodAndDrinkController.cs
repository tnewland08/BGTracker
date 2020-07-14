using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BGTracker.WebMVC.Controllers
{
    public class FoodAndDrinkController : Controller
    {
        // GET: FoodAndDrink
        public ActionResult Index()
        {
            return View();
        }
    }
}