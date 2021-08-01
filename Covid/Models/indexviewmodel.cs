using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Covid.Models
{
    public class indexviewmodel
    {
      
        public RegisterViewModel registermodel { get; set; }
      
        public cityviewmodel cityviewmodel { get; set; }

        [Required]
        [Display(Name = "city name")]
        public string cityname { get; set; }


        [Required]
        [Display(Name = "UserType")]
        public string UserType { get; set; }
    }
}