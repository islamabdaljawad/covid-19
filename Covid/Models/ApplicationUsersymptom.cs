using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Models
{
    public class ApplicationUsersymptom
    {
        public ApplicationUser ApplicationUser { get; set; }
        public symptom symptom { get; set; }
        public result result { get; set; }

        [Key, Column(Order = 1)]
        public string Id { get; set; }

        [Key, Column(Order = 2)]
        public int symptom_Id { get; set; }


        [Key, Column(Order = 3)]
        public int result_id { get; set; }

        public DateTime datetime { get; set; }
    }
}