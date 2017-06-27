using LogicLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using AuthASP.Mapping;
using DataLevel.Model;
using AuthASP.Models;

namespace AuthASP.Controllers
{
    public class ApiItemController : Controller
    {
        // GET: ApiItem
        public async Task<JsonResult> Index()
        {
            // TODO get item list and send as JSON
            var r = new ItemRepository();
            List<Item> items = await r.GetAllItem();
            List<ShopItem> shopItems = items.ToShopItems();
            var json = Json(shopItems, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}