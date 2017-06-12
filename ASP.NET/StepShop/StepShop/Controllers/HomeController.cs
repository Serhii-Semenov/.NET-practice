using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace StepShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using(StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                ViewBag.Items = entities.Items
                                        .Include(i => i.CategoryType)
                                        .ToList();

                if (ViewBag.Items == null) return View("Error");
            }
            return View();
        }
    }
}