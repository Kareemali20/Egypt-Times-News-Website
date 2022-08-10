using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Egypt_Times.Models;

namespace Egypt_Times.Controllers
{
    public class PersonController : Controller
    {

        DBModel dbContext = new DBModel();

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Person P = new Person();
            return View(P);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Person personModel)
        {
            using (DBModel dbModel = new DBModel())
            {
                dbModel.People.Add(personModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();

          
            return View("~/Views/News/NewsList.cshtml");
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}