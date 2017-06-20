using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StepShop.Models;

namespace StepShop.Controllers
{
    public class PhonesController : Controller
    {
        private ShopEntities1 db = new ShopEntities1();

        // GET: Phones
        public async Task<ActionResult> Index()
        {
            var phones = db.Phones.Include(p => p.Item).Include(p => p.Producer);
            return View(await phones.ToListAsync());
        }

        // GET: Phones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = await db.Phones.FindAsync(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // GET: Phones/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            var selectedList = await db.CategoryTypes.ToListAsync();
            ViewBag.SL = new SelectList(selectedList, "Id", "Name");

            return View(new CreatePhoneModel() { Item = new Item(), Phone = new Phone() });
        }

        // POST: Phones/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Phone.ProducerId,Phone.ItemId,Phone.Capacity,Phone.Weight,Phone.Display,Items.Name,Items.Description,Items.CategoryTypeId,Items.Price")] CreatePhoneModel phone)
        {
            if (ModelState.IsValid)
            {
                var item = db.Items.Add(new Item() { 
                    CategoryTypeId = phone.Item.CategoryTypeId,
                     Description = phone.Item.Description,
                      Name = phone.Item.Name,
                       Price = phone.Item.Price
                });
                db.Phones.Add(new Phone() {
                     Capacity = phone.Phone.Capacity,
                      Display = phone.Phone.Display,
                       Weight = phone.Phone.Weight,
                        Item = item
                });
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //if (ModelState.IsValid)
            //{
            //    db.Phones.Add(phone);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", phone.Phone.ItemId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", phone.Phone.ProducerId);
            return View(phone);
        }

        // GET: Phones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = await db.Phones.FindAsync(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", phone.ItemId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", phone.ProducerId);
            return View(phone);
        }

        // POST: Phones/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProducerId,ItemId,Capacity,Weight,Display")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", phone.ItemId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", phone.ProducerId);
            return View(phone);
        }

        // GET: Phones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = await db.Phones.FindAsync(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Phone phone = await db.Phones.FindAsync(id);
            db.Phones.Remove(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
