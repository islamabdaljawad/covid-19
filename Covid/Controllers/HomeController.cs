using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Covid.Models;
using Microsoft.AspNet.Identity;
namespace Covid.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "admin")]
        public ActionResult indexadmin()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

      
       
        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {

            using (var message = new MailMessage("islamzabdzallah@gmail.com", "islamzabdzallah@gmail.com"))
            {
                message.IsBodyHtml = true;
                message.Subject = "Contact";
                string body = "sender name:" + contact.Name + "<br>" +
                          "sender mail:" + contact.Email + "<br>" +
                          "message title:" + contact.Subject + "<br>" +
                          "message body:" + "<b>" + contact.Message + "<b>";
                message.Body = body;
                using (SmtpClient client = new SmtpClient
                {
                    
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("islamzabdzallah@gmail.com", "leftblank123456leftblankL")
                })
                {
                    client.Send(message);
                }
            }

            return RedirectToAction("Index");
            
        }

        [Authorize]
        public ActionResult informcase()
        {
            ViewBag.cityname = new SelectList(db.city.ToList(), "city_name", "city_name");
            ViewBag.show = false;

            return View();
        }

        [HttpPost]
        public ActionResult informcase(informcaseviewmodel model)
        {
            ViewBag.show = false;

            if (ModelState.IsValid)
            {
                ViewBag.cityname = new SelectList(db.city.ToList(), "city_name", "city_name");

              var u = from user in db.Users
                      join appc in db.ApplicationUsercity on user.Id equals appc.Id
                      select new { city = appc.city.city_name, cityname = user.cityname,email=user.Email };
              foreach (var s in u)
              {
                  if (s.city == model.cityname || s.cityname == model.cityname)
                  {
                      using (var message = new MailMessage("islamzabdzallah@gmail.com", s.email))
                      {
                          message.IsBodyHtml = true;
                          message.Subject = "new case of covid";
                          if(s.city !=null)
                              message.Body = "<p>"+"<b>" + "there are new  " + model.number + "case in " + s.city + "  city please be carfuly" +"</b>"+"</p>";
                          else
                              message.Body = "<p>" + "there are new  "+ model.number +"  case in "+ s.cityname + "  city please be carfuly";

                          using (SmtpClient client = new SmtpClient
                          {//https://accounts.google.com/DisplayUnlockCaptcha
                           //https://www.google.com/settings/security/lesssecureapps
                              
                              EnableSsl = true,
                              Host = "smtp.gmail.com",
                              Port = 587,
                              UseDefaultCredentials = false,
                              Credentials = new NetworkCredential("islamzabdzallah@gmail.com", "leftblank123456leftblankL")
                          })
                          {
                              client.Send(message);
                          }
                      }
                  }
              }
              ViewBag.show = true;
              ViewBag.mess = "you have inform the new cases successfully";
            }
            else
            {
                ViewBag.cityname = new SelectList(db.city.ToList(), "city_name", "city_name");

            }

            return View();
        }
    }
}