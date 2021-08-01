using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Covid.Models
{
    public class cityviewmodel
    {
        [Required(ErrorMessage = "Please select atleast one city")]
        public IEnumerable<string> selectedcities { get; set; }
        public IEnumerable<SelectListItem> cities { get; set; }
      
        

    }
}