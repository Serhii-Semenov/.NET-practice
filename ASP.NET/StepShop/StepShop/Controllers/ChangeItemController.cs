using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StepShop.Controllers
{
    public class ChangeItemController : Controller
    {
        // GET: ChangeItem
        public ActionResult IndexChange(int? id)
        {
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                ViewBag.Items = entities.Items.FirstOrDefault(a=>a.Id == id);

                if (ViewBag.Items == null) return View("Error"); // Сделать вьюху ошибки
            }


            return View();
        }
    }
}