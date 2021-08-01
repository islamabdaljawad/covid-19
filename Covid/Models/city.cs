using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace Covid.Models
{
    public class city
    {
       [Key]
        public int city_Id { get; set; }
        public string city_name { get; set; }
        public bool Isselected { get; set; }     
        public int itemid { get; set; }
        [Required]
        public virtual item item { get; set; }
        public IList<ApplicationUsercity> ApplicationUsercity { get; set; }
    }
}