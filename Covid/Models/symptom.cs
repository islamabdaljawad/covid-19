using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Covid.Models
{
    public class symptom
    {
        [Key]
        public int symptom_Id { get; set; }
        public string symptom_name { get; set; }
        public string symptom_descriptin { get; set; }
        public bool Isselected { get; set; }
        public IList<ApplicationUsersymptom> ApplicationUsersymptom { get; set; }
    }

    public class symptomviewmodel
    {
        public List<symptom> symptoms { get; set; }
    }


    public class testresultviewmodel
    {
        public int CoronaVirus { get; set; }
        public int Cold { get; set; }
        public int Flu { get; set; }
        public int Allergies { get; set; }
    }

    public class sympandresultviewmodel
    {
        public symptomviewmodel symptomviewmodel { get; set; }
        public testresultviewmodel testresultviewmodel { get; set; }
    }

   public class symview
   {
       public string  username { get; set; }
       public string symptomname  { get; set; }
       public string cityname { get; set; }
       public DateTime datetime { get; set; }
     //  public IEnumerable<string> symptomname { get; set; }





   }

}