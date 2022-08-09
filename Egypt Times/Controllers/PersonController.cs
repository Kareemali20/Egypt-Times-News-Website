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
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Person P = new Person();
            return View(P);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Person personModel)
        {
            using (Model1 dbModel = new Model1())
            {
                dbModel.People.Add(personModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Registration Succesful ";

            return View("~/Views/News_Person/Index.cshtml");
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}