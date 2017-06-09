using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using StepShop.Models;

namespace StepShop.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public async Task<ActionResult> Datails( int id)
        {
            using (ShopEntities entities = new ShopEntities())
            {
                ViewBag.Item = await entities.Items.Include(i => i.CategoryType).FirstOrDefaultAsync(i=> i.Id==id);
                if (ViewBag.Item==null)
                {
                    return Redirect("/Home/Index");
                }
                ViewBag.Coments = await entities.Comments.Include(i => i.Item).Where(i => i.ItemId == id).OrderByDescending(i=>i.Date).ToListAsync();
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            using (ShopEntities entities = new ShopEntities())
            {
                entities.Comments.Add(comment);
                await entities.SaveChangesAsync();
            }
            return RedirectToAction("Datails", "Item", new { id = comment.ItemId });
        }

    }
}