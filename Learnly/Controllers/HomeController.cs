using Learnly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learnly.Controllers
{
    public class HomeController : Controller
    {
        myDbContext _DB = new myDbContext();
        public ActionResult Index()
        {
            var brans = _DB.user.ToList();    
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}