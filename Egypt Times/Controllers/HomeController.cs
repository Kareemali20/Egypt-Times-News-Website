using Egypt_Times.Models;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Egypt_Times.Controllers
{
    public class HomeController : Controller
    {

     

        public HomeController()
        {
        }

        public ActionResult Index()
        {

           

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Request1()
        {

            Request requestObj = new Request
            {
                key = "44f035ff7eac4f36b9de5f7168169c95",
                country = "us",
                category = "technology",
                q = "sony"

            };

            string url = "https://newsapi.org/v2/top-headlines?country=us&apiKey=44f035ff7eac4f36b9de5f7168169c95";

            var jsonReq = JsonConvert.SerializeObject(requestObj);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "POST";


            var data = Encoding.UTF8.GetBytes(jsonReq);
            request.ContentType = @"application/json";
            request.ContentLength = data.Length;


            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            NewsResponse responseBack = JsonConvert.DeserializeObject<NewsResponse>(jsonRes);



            return View(responseBack);
        }   
    }
}