using Egypt_Times.Models;
using Newtonsoft.Json;
using Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NewsAPI.Controllers
{
    public class NewsController : Controller
    {

        // Request Methods
        public HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "GET";

            request.ContentType = @"application/json";

            return request;
        }

        public HttpWebRequest CreateRequest(string url, News newsModel)
        {
            string jsonReq = JsonConvert.SerializeObject(newsModel);
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


            return request;
        }


        public NewsController()
        {
            var request = CreateRequest("http://localhost/NewsAPI/News/LoadDropDownLists");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<SelectListItem> responseBack = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonRes);

            ViewBag.Data = responseBack;
        }


        [HttpGet]
        public ActionResult NewsList()
        {


            return View();
        }

        [HttpPost]
        public ActionResult NewsList(News Entity)
        {

            // Creating the request
            var request = CreateRequest("http://localhost/NewsAPI/News/NewsList", Entity);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Response responseBack = JsonConvert.DeserializeObject<Response>(jsonRes);

            if (!responseBack.Status)
            {
                ViewBag.Error = responseBack.Message;
                return View();
            }
            else
            {
                ViewBag.Succes = responseBack.Message;
            }

            return View();
        }

    }
}