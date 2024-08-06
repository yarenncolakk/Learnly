using LEARNLY.Custom;
using LEARNLY.Models;
using LEARNLY.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEARNLY.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        private LearnlyContext db = new LearnlyContext();
        // GET: Lesson
        public ActionResult LessonRequest(int branchId)
        {
            ViewBag.Teachers = new SelectList(db.Users.Where(x => x.RoleId == 1&& x.BranchId == branchId), "UserId", "Name");
            ViewBag.Topics = new SelectList(db.Topics.Where(x=>x.BranchId==branchId), "TopicId", "TopicName");
            return View();
        }
        [HttpPost]
        public ActionResult LessonRequest(LessonRequestViewModel lessonRequest)
        {
            if (ModelState.IsValid)
            {
                int userId = (int)Session["UserId"];
                var _request = new PrivateLesson();
                _request.StudentId = userId;
                _request.TopicId = lessonRequest.Topic;
                _request.Status = false;
                _request.PrivateLessonDate = lessonRequest.LessonDate;
                _request.TeacherId = lessonRequest.Teacher;
                db.PrivateLessons.Add(_request);
                db.SaveChanges();
                return RedirectToAction("Student", "Default");
            }
            else
            {                
                return View("Index");
            }
        }
        public ActionResult LessonList()
        {
            int userId = (int)Session["UserId"];
            int userRole = (int)Session["UserRoleId"];
            var lessons= userRole==2?db.PrivateLessons.Where(x => x.StudentId == userId).ToList():db.PrivateLessons.Where(x => x.TeacherId == userId).ToList();
            List<LessonListViewModel> lessonlist = new List<LessonListViewModel>();
            foreach (var lesson in lessons)
            {
                LessonListViewModel data = new LessonListViewModel();
                data.Id=lesson.PrivateLessonId;
                data.Status = !lesson.Status?"Tamamlanmadı":"Tamamlandı";
                data.Date = lesson.PrivateLessonDate;
                data.FullName = userRole == 2 ? db.Users.Where(x => x.UserId == lesson.TeacherId).Select(x => x.Name + " " + x.Surname).FirstOrDefault() : db.Users.Where(x => x.UserId == lesson.StudentId).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
                data.Topic = db.Topics.FirstOrDefault(x => x.TopicId == lesson.TopicId)?.TopicName;
                var branchId = db.Topics.FirstOrDefault(x => x.TopicId == lesson.TopicId).BranchId;
                data.Lesson = db.Branches.FirstOrDefault(x=>x.BranchId==branchId).BranchName;
                lessonlist.Add(data);
            }
            return View(lessonlist);
        }
        [HttpPost]
        public JsonResult CompleteLesson(int Id)
        {
            var lesson = db.PrivateLessons.FirstOrDefault(x => x.PrivateLessonId == Id);
            if (lesson != null)
            {
                lesson.Status = true;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}