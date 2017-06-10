using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using StepShop.Models;

namespace StepShop.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Details(int id)
        {
            // TODO: получить нужный элемент и отдать его представлению
            using(StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                ViewBag.Item = entities.Items
                    .Include(i => i.CategoryType)
                    .Include(i => i.Comments)
                    .FirstOrDefault(a => a.Id == id);
                // TODO : вывести полную информацию о товаре

                // TODO : добавить отзывы 
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            // TODO : save comment to DB
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {

                entities.Comments.Add(comment);
                entities.SaveChanges();

            }

            return View("Details", comment.ItemId);
        }
    }
}