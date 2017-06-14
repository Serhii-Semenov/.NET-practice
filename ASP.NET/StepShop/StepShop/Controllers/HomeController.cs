using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace StepShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            using(StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                ViewBag.Items = await entities.Items
                                        .Include(i => i.CategoryType)
                                        .ToListAsync();

                if (ViewBag.Items == null) return View("Error");
            }
            return View();
        }
    }
}