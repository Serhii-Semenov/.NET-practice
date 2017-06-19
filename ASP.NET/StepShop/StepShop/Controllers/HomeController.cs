using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections;
using StepShop.Models;
using System.Collections.Generic;
using Mapping;

namespace StepShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            using(StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                //ViewBag.Items = await entities.Items
                //                        .Include(i => i.CategoryType)
                //                        .ToListAsync();

                var it = await entities.Items.Include(i => i.CategoryType).ToListAsync();
                if (it == null) return View("Error");
                //List<ItemModelView> newItem =  new List<ItemModelView>();
                
                //foreach (var item in it)
                //{
                //    newItem.Add(ItemMapping.ItemModelToItemModelView(item));
                //}
                return View(ItemMapping.ItemModelToItemModelViews(it));
            }
        }
    }
}