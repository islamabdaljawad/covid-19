using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covid.Models;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Data;
using ClosedXML.Excel;
namespace Covid.Controllers
{

    
    public class symptomController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        
        // Point values.
        private const int Common = 20;
        private const int Sometimes = 5;
        private const int Mild = 3;
        private const int Rare = 1;
        private const int No = 0;

        // Values for each diagnosis.
        private int[,] Values =
{
    { Common, Common, Common, Sometimes, Sometimes, Sometimes, Sometimes, Rare, Rare, No },
    { Rare, Mild, No, Rare, Common, Common, Sometimes, No, Common, Common },
    { Common, Common, No, Common, Common, Common, Common, Sometimes, No, No },
    { Sometimes, Sometimes, Common, Sometimes, No, No, Sometimes, No, Common, Common },
};
        private const int DiarrheaSymptom = 7;

        // Indices in the array.
        private int Corona = 0;
        private int CommonCold = 1;
        private int Flu = 2;
        private int Allergies = 3;








        int[] check = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};









        //
        // GET: /symptom/
        [Authorize]
        public ActionResult test()
        {
            sympandresultviewmodel syr = new sympandresultviewmodel();
            symptomviewmodel symp = new symptomviewmodel();
           symp.symptoms =db.symptom.ToList<symptom>();
           syr.symptomviewmodel = symp; 
            return View(syr);
        }
        [HttpPost]
        public ActionResult test(sympandresultviewmodel model)
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy"));

            var selectedsymptom = model.symptomviewmodel.symptoms.Where(x=>x.Isselected == true).ToList<symptom>();
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Join(",", selectedsymptom.Select(x => x.symptom_Id)));
            string vs = sb.ToString();
            string[] authorsList = vs.Split(',');
            //return (sb.ToString());


            int num_diagnoses = Values.GetUpperBound(0) + 1;
            int num_symptoms = Values.GetUpperBound(1) + 1;
            int[] totals = new int[num_diagnoses];
            for (int diagnosis = 0; diagnosis < num_diagnoses; diagnosis++)
            {
                for (int symptom = 0; symptom < num_symptoms; symptom++)
                {
                     var selected = model.symptomviewmodel.symptoms.Where(x=>x.Isselected == true && x.symptom_Id==symptom+3 ).ToList<symptom>();

                     if (selected.Count == 1)
                     {
                         totals[diagnosis] += Values[diagnosis, symptom];
                     }
                }
            }
            var adultdirrhea = model.symptomviewmodel.symptoms.Where(x => x.Isselected == true && (x.symptom_Id == 10 && x.symptom_Id ==14)).ToList<symptom>();
           
            
            if (adultdirrhea.Count == 2)
            {
                totals[Flu] -= Values[Flu, DiarrheaSymptom];
            }


            sympandresultviewmodel sr = new sympandresultviewmodel();
            testresultviewmodel tr = new testresultviewmodel();

            // Display results.
            int[] labels = { tr.CoronaVirus, tr.Cold, tr.Flu, tr.Allergies };
            for (int diagnosis = 0; diagnosis < num_diagnoses; diagnosis++)
            {
                labels[diagnosis] = totals[diagnosis];

            }
            tr.CoronaVirus = labels[0];
            tr.Cold = labels[1];
            tr.Flu = labels[2];
            tr.Allergies = labels[3];
            sr.testresultviewmodel = tr;


            if (authorsList.Length > 1)
            {
                result result = new result();
                result.corona = tr.CoronaVirus;
                result.commoncold = tr.Cold;
                result.flu = tr.Flu;
                result.Allergies = tr.Allergies;
                db.result.Add(result);
                db.SaveChanges();

                foreach (var c in authorsList)
                {
                    ApplicationUsersymptom appus = new ApplicationUsersymptom();
                    appus.Id = User.Identity.GetUserId();
                    appus.symptom_Id = Convert.ToInt32(c);
                    appus.result_id = result.result_id;
                    appus.datetime = date;
                    db.ApplicationUsersymptom.Add(appus);
                    db.SaveChanges();
                }


            }
            return View("result", sr);
           
        }

        [Authorize]
        public ActionResult dysplayresult()
        {
           
            //var vc = (from user in db.Users
            //          from apps in user.ApplicationUsersymptom
            //          from uc in user.ApplicationUsercity
                   
            //         select new symview { username = user.UserName, cityname = user.cityname, symptomname = apps.symptom.symptom_name, datetime = apps.datetime });


            //var vc = (from user in db.Users
            //          from apps in user.ApplicationUsersymptom
            //          group apps by new { user.UserName, apps.datetime } into g

            //          select new symview { username = g.Key.UserName, datetime = g.Key.datetime, symptomname = String.Join(",", g.Select(x => x.symptom.symptom_name)) }).ToList();


            
            var vc = (from user in db.Users
                      from apps in user.ApplicationUsersymptom
                      group apps  by new { apps.ApplicationUser.UserName, apps.datetime } into g
                      select new{username = g.Key.UserName,cityname=g.Select(v=>v.ApplicationUser.cityname).FirstOrDefault(),datetime = g.Key.datetime, symptomname =g.Select(s=>s.symptom.symptom_name) });

            var xc=vc.AsEnumerable().Select(x=> new symview { username =x.username,cityname=x.cityname ,datetime = x.datetime, symptomname = String.Join("-",x.symptomname)});

        
            return View(xc.ToList());
        }





        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("username"),
                                            new DataColumn("cityname"),
                                            new DataColumn("datetime"),
                                            new DataColumn("symptomname") });
            var vc = (from user in db.Users
                      from apps in user.ApplicationUsersymptom
                      group apps by new { apps.ApplicationUser.UserName, apps.datetime } into g
                      select new { username = g.Key.UserName, cityname = g.Select(v => v.ApplicationUser.cityname).FirstOrDefault(), datetime = g.Key.datetime, symptomname = g.Select(s => s.symptom.symptom_name) });

            var xc = vc.AsEnumerable().Select(x => new symview { username = x.username, cityname = x.cityname, datetime = x.datetime, symptomname = String.Join("-", x.symptomname) });

        
            foreach (var result in xc)
            {
                dt.Rows.Add(result.username, result.cityname, result.datetime, result.symptomname);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");

                }
            }
        }
	}
}