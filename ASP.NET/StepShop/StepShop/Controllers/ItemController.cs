using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using StepShop.Models;
using System.Threading.Tasks;

namespace StepShop.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public async Task<ActionResult> Details(int? id)
        {
            // TODO: получить нужный элемент и отдать его представлению
            using(ShopEntities1 entities = new ShopEntities1())
            {
                ViewBag.Item = await entities.Items
                    .Include(i => i.CategoryType)
                    .Include(i=>i.Comments)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (ViewBag.Item == null)
                    return Redirect("/Home/Index");
                // TODO : добавить отзывы 
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(Comment comment)
        {
            // TODO : save comment to DB

            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                comment.Date = DateTime.Now;
                entities.Comments.Add(comment);
                await entities.SaveChangesAsync();
            }
            return RedirectToAction("Details", "Item", new { id = comment.ItemId });
        }
    }
}