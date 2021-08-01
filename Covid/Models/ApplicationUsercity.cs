using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Covid.Models
{
    public class ApplicationUsercity
    {
   

        public ApplicationUser ApplicationUser { get; set; }
        public city city { get; set; }

        [Key, Column(Order = 1)]
        public string Id { get; set; }

        [Key, Column(Order = 2)]
        public int city_Id { get; set; }
    }
}