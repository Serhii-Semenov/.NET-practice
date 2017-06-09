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
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            using (ShopEntities entities = new ShopEntities())
            {
                ViewBag.Items = await entities.Items.Include(i => i.CategoryType).ToListAsync();
                return View();
            }
                
        }
    }
}