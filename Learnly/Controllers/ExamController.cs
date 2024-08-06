using LEARNLY.Custom;
using LEARNLY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEARNLY.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        private LearnlyContext db = new LearnlyContext();
        // GET: Exam
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StartExam(int branchId)
        {
            var exams = db.Questions.Where(x => x.BranchId == branchId).GroupBy(x => x.TopicId).ToList();
            List<Question> questions = new List<Question>();
            foreach (var exam in exams)
            {
                Random rnd = new Random();
                var list = new List<Question>();
                foreach (var item in exam)
                {
                    list.Add(item);
                }

                int index = rnd.Next(list.Count);
                questions.Add(list[index]);
            }

            var examId = db.ExamQuestions.GroupBy(x => x.ExamId).Count() + 1;
            foreach (var item in questions)
            {
                var question = new ExamQuestion();
                question.QuestionId = item.QuestionId;
                question.ExamId = examId;
                db.ExamQuestions.Add(question);

            }
            db.SaveChanges();
            return RedirectToAction("TakeExam", new { examId = examId, questionIndex = 0 });
        }
        // Sınav ekranını göstermek için
        public ActionResult TakeExam(int examId, int questionIndex)
        {
            var examQuestions = (from eq in db.ExamQuestions
                                 join q in db.Questions on eq.QuestionId equals q.QuestionId
                                 where eq.ExamId == examId
                                 select q).ToList();

            if (questionIndex >= examQuestions.Count)
            {
                return RedirectToAction("CompleteExam", new { examId = examId });
            }

            var question = examQuestions[questionIndex];
            ViewBag.ExamId = examId;
            ViewBag.QuestionIndex = questionIndex;

            return View(question);
        }
        [HttpPost]
        public ActionResult SubmitAnswer(int examId, int questionIndex, int questionId, string selectedOption)
        {
            int userId = (int)Session["UserId"];
            // Cevabı dbye yaz
            var studentAnswer = new StudentAnswer
            {
                QuestionId = questionId,
                Answer = selectedOption,
                ExamId = examId,
                UserId = userId
            };

            db.StudentAnswers.Add(studentAnswer);
            db.SaveChanges();

            // Bir sonraki soruya geçiş
            return RedirectToAction("TakeExam", new { examId = examId, questionIndex = questionIndex + 1 });
        }

        // Sınavı tamamlama ekranı
        public ActionResult CompleteExam(int examId)
        {
            int userId = (int)Session["UserId"];
            var answers = db.StudentAnswers.Where(x => x.ExamId == examId && x.UserId == userId).ToList();
            int true_answers = 0;
            int false_answers = 0;

            foreach (var answ in answers)
            {
                var correct_answ = db.Questions.Where(x => x.QuestionId == answ.QuestionId).FirstOrDefault().Answer;
                //var sayac=correct_answ == answ.cevap ? true_answers++ : false_answers++;
                if (correct_answ == answ.Answer)
                {
                    true_answers++;
                }
                else
                {
                    false_answers++;
                }
            }

            var result = new ExamResult();
            result.UserId = userId;
            result.ExamId = examId;
            result.ExamDate = DateTime.Now;
            result.TotalCorrectCount = true_answers;
            result.TotalIncorrectCount = false_answers;
            db.ExamResults.Add(result);
            db.SaveChanges();
            ViewBag.Correct = true_answers;
            ViewBag.Incorrect = false_answers;
            ViewBag.ExamId = examId;
            return View();
        }
        
    }
}
