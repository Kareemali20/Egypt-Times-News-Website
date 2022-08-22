using Egypt_Times.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsAPI.Models
{
    public class NewsResponse
    {
        public string key { get; set; }
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }

        public NewsResponse()
        {
            this.key = "44f035ff7eac4f36b9de5f7168169c95";
        }

    }
}