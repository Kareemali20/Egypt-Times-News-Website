using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Egypt_Times.Models;
using Scrypt;

namespace Egypt_Times.Controllers
{
    public class PersonController : Controller
    {

        DBModel dbContext = new DBModel();
        ScryptEncoder encoder = new ScryptEncoder();  

        [HttpGet]
        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Person personModel)
        {
            // Checking if the user is already registered
            var isRegisteredUser = (from c in dbContext.People
                                    where c.Email.Equals(personModel.Email)
                                    select c).SingleOrDefault();
            if(isRegisteredUser != null)
            {
                ViewBag.Error = "Username already registered!";
                return View();
            }

            // Hashing the user password
            personModel.Password = encoder.Encode(personModel.Password);

            // Adding the user to the database
            using (DBModel dbModel = new DBModel())
            {
                dbModel.People.Add(personModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();

            var newsList = dbContext.News.ToList();

            List<SelectListItem> lookup = new List<SelectListItem>();
            foreach (var item in newsList)
            {
                lookup.Add(
                    new SelectListItem() { Text = item.TypeName, Value = item.ID.ToString() }
                    );

            }

            ViewBag.Data = lookup;


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
            // Checking if the user information is correct
            var isRegisteredUser = (from c in dbContext.People
                                    where c.Email.Equals(personModel.Email)
                                    select c).SingleOrDefault();


            if (isRegisteredUser == null)
            {
                ViewBag.Error = "Email Or Password Not valid";
                return View();
            }

            bool isCorrectPassword = encoder.Compare(personModel.Password, isRegisteredUser.Password);
            if (!isCorrectPassword)
            {
                ViewBag.Error = "Email Or Password Not valid";
                return View();

            }
            else
            {
                Session["User"] = personModel;
            }

            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}