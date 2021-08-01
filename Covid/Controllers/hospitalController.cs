using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covid.Models;
using Microsoft.AspNet.Identity;

namespace Covid.Controllers
{
    [Authorize]
    public class hospitalController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext(); 
       
        [HttpGet]
        public ActionResult enroll()
        {
            ViewBag.show = false;

            return View();
        }

        [HttpPost]
        public ActionResult enroll(avilable_leds avilable)
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));
            ViewBag.show = false;

            if (ModelState.IsValid)
            {
                avilable.show = true;
                avilable.UserId = User.Identity.GetUserId();
                db.avilable_leds.Add(avilable);
                db.SaveChanges();
                ViewBag.show = true;
                ViewBag.mess = "you have enroll the avilable beds successfully";
            }
            return View();
        }


        public ActionResult displayhospitals()
        {
            var UserId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(a => a.Id == UserId).SingleOrDefault();
            var q = (from us in db.Users
                     join avl in db.avilable_leds
                     on us.Id equals avl.UserId
                     where us.cityname == CurrentUser.cityname
                     select new hospitals  { hospital = us.UserName, date=avl.date, number=avl.number }).ToList();

            return View(q);
        }

	}
}