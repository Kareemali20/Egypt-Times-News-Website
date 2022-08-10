using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Egypt_Times.Models;

namespace Egypt_Times.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        DBModel dbContext = new DBModel();

        public ActionResult NewsList()
        {
            var newsList = dbContext.News.ToList();


            if (newsList != null)
            {
                

                List<SelectListItem> lookup = new List<SelectListItem>();
                foreach (var item in newsList)
                {
                    lookup.Add(
                        new SelectListItem() { Text = item.TypeName, Value = item.ID.ToString() }
                        );

                }

                ViewBag.Data = lookup;
            }



            return View();
        }

        [HttpPost]
        public ActionResult NewsList(News entity)
        {
            var userList = dbContext.People.ToList();
            ViewBag.Data2 = userList[userList.Count - 1].ID;
            
            dbContext.News.Add(entity);
            dbContext.SaveChanges();


            return View();
        }

        public ActionResult Add()
        {

            return View();

        }
    }
}