using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.IO;
using Covid.Models;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;    
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;

namespace Covid.Models
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {

            //using (var message = new MailMessage("studenthamada@gmail.com", "studenthamada@gmail.com"))
            //{
            //    message.Subject = "Message Subject test";
            //    message.Body = "Message body test at " + DateTime.Now;
            //    using (SmtpClient client = new SmtpClient
            //    {
            //        EnableSsl = true,
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        Credentials = new NetworkCredential("studenthamada@gmail.com", "hamada12345*")
            //    })
            //    {
            //        client.Send(message);
            //    }
            //}
            ApplicationDbContext db = new ApplicationDbContext();

            //foreach (var n in db.item)
            //{
            //    item item = db.item.Find(n.id);
            //    db.item.Remove(item);
            //    db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('items', RESEED, 0)");
            //    db.SaveChanges();
            //}


            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.covidactnow.org/v2/states.json?apiKey=a8ea6f190c0b409c823bb7959a9c2052"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            dynamic array = JsonConvert.DeserializeObject(jsonString);

            List<item> items = JsonConvert.DeserializeObject<List<item>>(jsonString);
            foreach (var item in array)
            {
                string state = item.state;
                item itm = db.item.Where(x => x.state == state).FirstOrDefault();
                itm.id = itm.id;
                itm.state = item.state;
                itm.newCases = item.actuals.newCases;
                itm.newDeaths = item.actuals.newDeaths;
                itm.vaccinationsCompleted = item.actuals.vaccinationsCompleted;
                itm.vaccinesDistributed = item.actuals.vaccinesDistributed;
                db.SaveChanges();
                // MessageBox.Show(item.actuals.newDeaths.ToString());
            }


            var q =( from it in db.item
           join cit in db.city
           on it.id equals cit.itemid 
          select new {city=cit.city_name,state=it.state,newc=it.newCases}).ToList();
        
            foreach (var i in q)
            {
                    foreach (var u in db.Users)
                    {
                        if(u.cityname==i.city)
                        {
                            using (var message = new MailMessage("islamzabdzallah@gmail.com", u.Email))
                           {
                            message.IsBodyHtml = true;
                            message.Subject = "Message new cases";
                        
                            message.Body = "<p>"+"<b>"+"the new cases in your state "+ i.state +" today equal " + i.newc + "  cases please be carfuly"+"</b>"+"</p>";
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

                        }
                  }
           }
            }
            
        }
    }
