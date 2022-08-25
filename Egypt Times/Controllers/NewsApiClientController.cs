using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Egypt_Times.Controllers
{
    public class NewsApiClientController : Controller
    {

        public HttpWebRequest CreateNewsRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "GET";
            request.ContentType = "application/json";


            return request;
        }

        public ActionResult Index()
        {
            // Method 1
            //var request = CreateNewsRequest("https://newsapi.org/v2/top-headlines?country=de&category=business&apiKey=44f035ff7eac4f36b9de5f7168169c95");
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();

            // Method 2 
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://newsapi.org/v2");
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("https://newsapi.org/v2/top-headlines?country=de&category=business&apiKey=44f035ff7eac4f36b9de5f7168169c95").Result;


            return View();
        }
    }
}