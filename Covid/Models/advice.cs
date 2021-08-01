using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid.Models
{
    public class advice
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool show { get; set; }
    }
}