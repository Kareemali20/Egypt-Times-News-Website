using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Egypt_Times.Models;

namespace Egypt_Times.Controllers
{
    public class News_PersonController : Controller
    {
        // GET: News_Person
        private readonly News_Person _context;
        public News_PersonController()
        {
            _context = new News_Person();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var person = new News_Person
            {
            };
            return View("Index");
        }

    }
}   