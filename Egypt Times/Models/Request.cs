using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Egypt_Times.Models
{
    public class Request
    {
        public string key { get; set; }
        public string country { get; set; }
        public string category { get; set; }
        public string q { get; set; }
        public int pageSize { get; set; }
        public int page { get; set; } 



    }
}