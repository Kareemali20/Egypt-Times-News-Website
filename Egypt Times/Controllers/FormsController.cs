using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Egypt_Times.Controllers
{
    public class FormsController : Controller
    {
        // GET: Forms
   
        public ActionResult LogIn()
        {
            return View();
        }

    }
}