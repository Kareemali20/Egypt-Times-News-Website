using Egypt_Times.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Egypt_Times.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        DBModel dbContext = new DBModel();

        public NewsController()
        {
            LoadDropDownLists();
        }

        public void LoadDropDownLists()
        {
            var newsList = dbContext.News.ToList();

            List<SelectListItem> lookup = new List<SelectListItem>();
            foreach (var item in newsList)
            {
                lookup.Add(
                    new SelectListItem() { Text = item.TypeName, Value = item.ID.ToString() }
                    );

            }

            ViewBag.Data = lookup;
        }


        public ActionResult NewsList()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewsList(News entity)
        {

            var newsList = dbContext.News.ToList();
            var userList = dbContext.People.ToList();

            UserNews userNews = new UserNews
            {
                User_ID = userList[userList.Count - 1].ID,
                News_ID = newsList[entity.ID - 1].ID
            };

            // Checking if the news selection already exists or not
            var isExtestd = dbContext.User_News
                .Where(x => x.User_ID == userNews.User_ID && x.News_ID == userNews.News_ID)
                .FirstOrDefault();
            if(isExtestd == null)
            {
                dbContext.User_News.Add(userNews);
                dbContext.SaveChanges();
            }
            else
            {
                ViewBag.Error = "News Already exists";
            }

            ModelState.Clear();
            return View();
        }

    }
}