using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covid.Models;
using System.Net;
using System.Data.Entity;
namespace Covid.Controllers
{
    [Authorize(Roles = "admin")]
    public class adviceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        //
        // GET: /advice/
        public ActionResult Index()
        {
            
            return View(db.advice.Where(x=>x.show==true).ToList());
        }
        
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(advice advice)
        {
            advice.show = true;
            db.advice.Add(advice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advice advice = db.advice.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }
        [HttpPost]
        public ActionResult edit(advice advice)
        {
            if(ModelState.IsValid)
            {

                db.Entry(advice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advice);
        }
        

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advice advice = db.advice.Find(id);
 
                if (advice == null)
                {
                    return HttpNotFound();
                }
            
            return View(advice);
            
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advice advice = db.advice.Find(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return View(advice);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            advice advice = db.advice.Find(id);
            advice.show = false;
            db.Entry(advice).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}