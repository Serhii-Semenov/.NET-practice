using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;
using StepShop.Models;
using System.Web.UI.WebControls;
using System.Text;

namespace StepShop.Controllers
{
    public class ChangeItemController : Controller
    {
        // GET: ChangeItem
        [HttpGet]
        public async Task<ActionResult> Change(int? id = null)
        {
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                var item = await entities.Items
                    .Include(a => a.CategoryType)
                    .Include(a => a.ItemImages)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (item == null) return Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки

                var selectedList = await entities.CategoryTypes.ToListAsync();
                ViewBag.SL = new SelectList(selectedList, "Id","Name");

                return View("Change", item);
            }  
        }

        [HttpPost]
        public async Task<ActionResult> Change(Item it)
        {
            if (it == null) Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки
            using (StepShop.Models.ShopEntities1 entities = new Models.ShopEntities1())
            {
                var item = await entities.Items
                    .FirstOrDefaultAsync(a => a.Id == it.Id);

                if (item == null) return Content("Error", "text/plain", Encoding.UTF8); // Сделать вьюху ошибки






                return View("Change", item);
            }
        }

    }
}