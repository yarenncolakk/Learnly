using Learnly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learnly.Controllers
{
    public class DefaultController : Controller
    {
        myDbContext _DB = new myDbContext();
        // GET: Default
        public ActionResult StudentPage()
        {
            return View();
        }

        public ActionResult TeacherPage()
        {
            return View();  
        }
    }
}