using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Rest;
using System.Text.Json;
using Newtonsoft.Json;

namespace NewsAPI.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        DBModel dbContext = new DBModel();
        Response response = new Response();

        public NewsController()
        {
            LoadDropDownLists();
        }

        public string LoadDropDownLists()
        {
            var newsList = dbContext.News.ToList();

            List<SelectListItem> lookup = new List<SelectListItem>();
            foreach (var item in newsList)
            {
                lookup.Add(
                    new SelectListItem() { Text = item.TypeName, Value = item.ID.ToString() }
                    );
                 
            }

            return JsonConvert.SerializeObject(lookup);
        }


        [HttpGet]
        public string NewsList()
        {

            return "News Test";
        }

        [HttpPost]
        public string NewsList(News entity)
        {

            string output;

            var newsList = dbContext.News.ToList();
            var userList = dbContext.Users.ToList();

            UserNews userNews = new UserNews
            {
                User_ID = userList[userList.Count - 1].ID,
                News_ID = newsList[entity.ID - 1].ID
            };

            // Checking if the news selection already exists or not
            var isExist = dbContext.User_News
                .Where(x => x.User_ID == userNews.User_ID && x.News_ID == userNews.News_ID)
                .FirstOrDefault();
            if(isExist == null)
            {
                dbContext.User_News.Add(userNews);
                dbContext.SaveChanges();

                response.Status = true;
                response.Message = "Added Succesfuly";
                output = JsonConvert.SerializeObject(response);

            }
            else
            {
                response.Status = false;
                response.Message = "News Already exists";

                output = JsonConvert.SerializeObject(response);
                return output;
            }

            ModelState.Clear();
            return output;
        }



    }
}