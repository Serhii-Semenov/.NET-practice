using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using StepShop.Models;
using System.Threading.Tasks;
using System.Text;

namespace StepShop.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item/Details --------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            // done: получить нужный элемент и отдать его представлению
            using(ShopEntities1 entities = new ShopEntities1())
            {
                var _item = await entities.Items
                    .Include(i => i.CategoryType)
                    .Include(i=>i.Comments)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (_item == null)
                    return Redirect("/Home/Index");

                _item.Comments = _item.Comments.OrderByDescending(r=>r.Date).ToList();
                string path = "Content/Images/Items/" + _item.CategoryTypeId + "/" + _item.Id + ".jpg";

                return View(new MyShopModel() { item = _item, ImagePath = path });
            }
        }

        // POST: Item/AddComment
        [HttpPost]
        public async Task<ActionResult> AddComment(Comment comment)
        {
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                comment.Date = DateTime.Now;
                entities.Comments.Add(comment);
                await entities.SaveChangesAsync();
            }
            return RedirectToAction("Details", "Item", new { id = comment.ItemId });
        }


        // GET: Item/Create --------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                var selectedList = await entities.CategoryTypes.ToListAsync();
                ViewBag.SL = new SelectList(selectedList, "Id", "Name");
            }
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public async Task<ActionResult> Create(Item it)
        {
            if (it == null) Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки
            try
            {
                using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
                {
                    entities.Items.Add(it);
                    await entities.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        // GET: Item/Edit ----------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Edit(int? id = null)
        {
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                var item = await entities.Items
                    .Include(a => a.CategoryType)
                    .Include(a => a.ItemImages)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (item == null) return Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки

                var selectedList = await entities.CategoryTypes.ToListAsync();
                ViewBag.SL = new SelectList(selectedList, "Id", "Name");
                return View("Edit", item);
            }
        }

        // POST: Item/Edit
        [HttpPost]
        public async Task<ActionResult> Edit(Item it)
        {
            if (it == null) Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки
            try
            {
                // done: Add update logic here
                using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
                {
                    entities.Entry(it).State = EntityState.Modified;
                    await entities.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Edit", it.Id);
        }

        // GET: Item/Delete ----------------------------------------------------------------------------
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}