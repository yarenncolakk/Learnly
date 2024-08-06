using LEARNLY.Custom;
using LEARNLY.Models;
using LEARNLY.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LEARNLY.Controllers
{
    public class UserController : Controller
    {

        private LearnlyContext db = new LearnlyContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var _user = new User();
                _user.Email = user.Email;
                _user.Name = user.Name;
                _user.Surname = user.Surname;
                _user.Password = HashPassword(user.Password);
                _user.BranchId = 0;
                _user.RoleId = 2;
                db.Users.Add(_user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            var hashedPassword = HashPassword(user.Password);
            var _user = db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == hashedPassword);
            if (_user != null)
            {
                // Giriş başarılı, oturum açma işlemlerini gerçekleştirin
                Session["UserId"] = _user.UserId;
                Session["UserName"] = _user.Name;
                Session["UserEmail"] = _user.Email;
                Session["UserSurame"]= _user.Surname;
                Session["UserRoleId"] = _user.RoleId;
                FormsAuthentication.SetAuthCookie(_user.UserId.ToString(), false);
                return _user.BranchId == 0 ? RedirectToAction("Student", "Default") : RedirectToAction("LessonList", "Lesson");
            }
            ViewBag.Message = "Geçersiz email veya şifre";
            return View("Login", user);
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        [HttpPost]
        public JsonResult IsEmailAvailable(string email)
        {
            // EMail adresi Veritabanında kontrol ediliyor
            bool isAvailable = !db.Users.Any(u => u.Email == email);
            return Json(isAvailable);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}