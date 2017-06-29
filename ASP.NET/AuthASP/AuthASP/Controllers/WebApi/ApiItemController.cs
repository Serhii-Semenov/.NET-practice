using LogicLevel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using AuthASP.Mapping;
using DataLevel.Model;
using AuthASP.Models;
using System.Web.Http;
using System.Linq;

namespace AuthASP.Controllers
{
    public class ApiItemController : ApiController
    {
        // GET: ApiItem
        //public async Task<string> Get()
        //{
        //    // TODO get item list and send as JSON
        //    var r = new ItemRepository();
        //    List<Item> items = await r.GetAllItem();
        //    List<ShopItem> shopItems = items.ToShopItems();
        //    var json = Json(shopItems.Select(a => new {Name = a.Name}));
        //    return json.ToString();
        //}

        public string Get()
        {
            return System.DateTime.Now.ToString();
        }
    }
}