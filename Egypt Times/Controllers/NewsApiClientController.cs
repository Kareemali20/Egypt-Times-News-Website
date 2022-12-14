using Egypt_Times.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Egypt_Times.Controllers
{
    public class NewsApiClientController : Controller
    {
        public NewsResponse RequestAndGetResponse(Request requestObj)
        {
            NewsResponse responseBack = null;

            // Creating the url
            string url = "https://newsapi.org/v2/top-headlines?";
            url += "country=" + requestObj.country + "&";
            url += "category=" + requestObj.category + "&";
            url += "apiKey=" + requestObj.key;


            // Creating the request
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "GET";
            request.UserAgent = "PostmanRuntime/7.29.2";

            request.ContentType = @"application/json";

            // Getting the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            responseBack = JsonConvert.DeserializeObject<NewsResponse>(jsonRes);

            return responseBack;
        }

        // Request Functions
        public Request CreateRandomRequestObject()
        {
            Random random = new Random();

            List<string> categories = new List<string>()
            {
                "business",
                "entertainment",
                "general",
                "health",
                "science",
                "sports",
                "technology"
            };

            List<string> countries = new List<string>()
            {
                "us",
                "ua",
                "ae",
                "ar",
                "at",
                "cz"
            };

            Request requestObj = new Request
            {
                category = categories[random.Next(0, categories.Count)],
                country = countries[random.Next(0, countries.Count)],
                key = "44f035ff7eac4f36b9de5f7168169c95",
            };

            return requestObj;
        }

        public Request CreateUserCustomRequest(string category)
        {
            Request requestObject = new Request
            {
                category = category,
                key = "44f035ff7eac4f36b9de5f7168169c95",
                country = "us"
            };

            return requestObject;
        }

        public new ActionResult Request()
        {

            Request requestObj = CreateRandomRequestObject();
            NewsResponse responseBack = RequestAndGetResponse(requestObj);


            return View(responseBack);
        }

        //[HttpPost]
        public ActionResult UserCustomNews(string btnSubmit)
        {
            Request requestObj = CreateUserCustomRequest(btnSubmit);
            NewsResponse responseBack = RequestAndGetResponse(requestObj);
            responseBack.responseType = btnSubmit;

            return View(responseBack);
        }
    }
}