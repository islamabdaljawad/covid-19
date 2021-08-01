using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace Covid.Models
{
    public class result
    {
        [Key]
        public int result_id { get; set; }
        public int corona { get; set; }
        public int commoncold { get; set; }
        public int flu { get; set; }
        public int Allergies { get; set; }
        public IList<ApplicationUsersymptom> ApplicationUsersymptom { get; set; }

    }
}