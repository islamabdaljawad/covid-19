using Covid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid.Controllers
{
    public class mapController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /map/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMapMarker()
        {
           db.Configuration.ProxyCreationEnabled = false;
            var ListOfAddress = db.item.ToList();

            return Json(ListOfAddress, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PS()
        {
            return View();
        }

        public ActionResult GPS()
        {
            return View();
        }

	}
}