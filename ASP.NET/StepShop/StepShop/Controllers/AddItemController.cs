using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StepShop.Models;
using System.Data.Entity;
using System.Text;

namespace StepShop.Controllers
{
    public class AddItemController : Controller
    {

        public async Task<ActionResult> Add() 
        {
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                var selectedList = await entities.CategoryTypes.ToListAsync();
                ViewBag.SL = new SelectList(selectedList, "Id", "Name");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Item it)
        {
            if (it == null) Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                entities.Items.Add(it);
                await entities.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
