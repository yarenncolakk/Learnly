using Learnly.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace Learnly.Controllers
{
    public class UserController : Controller
    {
        myDbContext _DB = new myDbContext();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost] //frontend den gelen verilerle işlem yapılacak
        public ActionResult Login(string kullaniciadi, string parola)
        {
            var kullanicilar = _DB.user.Where(x => x.ad == kullaniciadi && x.parola == parola).ToList();
            if (kullanicilar.Count() > 0)
            {
                //int rol = kullanicilar.Where(x => x.rol_id == 1).Count();
                var b = Convert.ToInt16(kullanicilar.Select(x => x.rol_id));
                if (b == 1)
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

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(string userName, string email, string phone, string password)
        {
            var newUser = new KULLANICILAR();
            newUser.ad = userName;
            newUser.eposta = email;
            //user.
            newUser.parola = password;
            _DB.user.Add(newUser);
            _DB.SaveChanges();
            return View("Login");

            //var ad = _DB.user.Where(x => x.ad == userName).ToList();  
            //if(ad.Count() == 1)
            //{
            //    ViewBag.Message = "Bu kullanıcı adı alındı.";
            //   return View();
            //}

            //var eposta = _DB.user.Where(x => x.eposta == email).ToList();
            //if (eposta.Count() ==  1)
            //{
            //    ViewBag.Message = "Bu e-mail başka bir kullanıcı tarafından kullanılıyor.";
            //    return View();
            //}
        }
    }
}
