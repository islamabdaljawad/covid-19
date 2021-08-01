using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Resources;

namespace Covid.Models
{
    public class item
    {
        [Key]
        public int id { get; set; }
        public string state { get; set; }
        public int newCases { get; set; }
        public int newDeaths { get; set; }
        public int vaccinesDistributed { get; set; }
        public int vaccinationsCompleted { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public virtual city city { get; set; }
    }
}