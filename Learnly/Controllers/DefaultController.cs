using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEARNLY.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Student()
        {
            return View();
        }
        public ActionResult Instructor()
        {
            return View();
        }
    }
}