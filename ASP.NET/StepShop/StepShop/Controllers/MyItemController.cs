using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StepShop.Controllers
{
    public class MyItemController : Controller
    {
        // GET: MyItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyItem/Delete/5
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
