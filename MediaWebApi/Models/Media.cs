using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaWebApi.Models
{
    public class Media
    {
        [Key]
        public long Id { get; set; }
        public string MediaUri { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        

    }
}