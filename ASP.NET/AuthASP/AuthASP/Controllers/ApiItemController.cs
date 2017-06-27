using LogicLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AuthASP.Controllers
{
    public class ApiItemController : Controller
    {
        // GET: ApiItem
        public async Task<JsonResult> Index()
        {
            // TODO get item list and send as JSON
            var c = new ItemRepository();
            var i = await c.GetAllItem();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
    }
}