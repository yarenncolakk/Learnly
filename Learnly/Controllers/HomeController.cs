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
            var question = _DB.user.ToList();  
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kullaniciadi,string parola)
        {
            var kullanicilar = _DB.user.Where(x=>x.ad==kullaniciadi&&x.parola==parola).ToList();
            if (kullanicilar.Count() > 0)
            {
                //int rol = kullanicilar.Where(x => x.rol_id == 1).Count();
                var b=Convert.ToInt16(kullanicilar.Select(x=>x.rol_id));
                if(b==1)
                {
                    return View("OgretmenAnasayfa");  //bu sayfayı dön
                }
                else
                {
                    return View("OgrenciAnasayfa");
                }
            }
            else 
            {

                ViewBag.Message = "Kullanıcı Adı veya Şifre Hatalı!";
                return View();
            }
            
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