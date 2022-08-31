using Egypt_Times.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Egypt_Times.Models
{
    public class NewsResponse
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public string responseType { get; set; }
        public List<Article> articles { get; set; }

        public NewsResponse()
        {
        }

    }
}