using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Resources;
namespace Covid.Models
{
    public class avilable_leds
    {
        [Key]
        public int hospital_Id { get; set; }
        public int number { get; set; }
        public DateTime date { get; set; }
        public bool show { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}