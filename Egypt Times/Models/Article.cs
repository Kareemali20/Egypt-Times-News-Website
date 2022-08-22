using System;
using Egypt_Times.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsAPI.Models
{
    public class Article
    {
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public string url { get; set; } 
        public string imageUrl { get; set; }

        public DateTime? publishedAt { get; set; }

    }
}