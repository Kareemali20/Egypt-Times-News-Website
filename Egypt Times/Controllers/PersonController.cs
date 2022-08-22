using Egypt_Times.Models;
using Newtonsoft.Json;
using Scrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NewsAPI.Controllers
{
    public class PersonController : Controller
    {

        public HttpWebRequest CreateRequest(string url, Person personModel)
        {
            string jsonReq = JsonConvert.SerializeObject(personModel);
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

        public HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.Method = "GET";

            request.ContentType = @"application/json";

            return request;
        }

        public void DrawDropDownList()
        {

            var request = CreateRequest("http://localhost/NewsAPI/News/LoadDropDownLists");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<SelectListItem> responseBack = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonRes);

            ViewBag.Data = responseBack;
        }



        [HttpGet]
        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Person personModel)
        {

            // Creating the request
            var request = CreateRequest("http://localhost/NewsAPI/User/signup", personModel);
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Response responseBack = JsonConvert.DeserializeObject<Response>(jsonRes);
            
            if (!responseBack.Status)
            {
                ViewBag.Error = responseBack.Message;
                return View();
            }

            DrawDropDownList();
            return View("~/Views/News/NewsList.cshtml");
        }

        [HttpGet]
        public ActionResult LogIn()
        {


            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Person personModel)
        {
            var request = CreateRequest("http://localhost/NewsAPI/User/login", personModel);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonRes = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Response responseBack = JsonConvert.DeserializeObject<Response>(jsonRes);

            if (!responseBack.Status)
            {
                ViewBag.Error = responseBack.Message;
                return View();
            }

            Session["email"] = personModel.Email;
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}