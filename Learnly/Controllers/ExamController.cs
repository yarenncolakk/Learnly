using Learnly.Models;
using Learnly.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learnly.Controllers
{
    public class ExamController : Controller
    {
        myDbContext _DB = new myDbContext();
        // GET: Exam
        public ActionResult Exam(/*int branch_id*/)
        {
            int branch_id = 1;
            var exams = _DB.question.Where(x => x.brans_id == branch_id).GroupBy(x=>x.konu_id).ToList();
            List<SORULAR> questions = new List<SORULAR>();
            foreach (var exam in exams)
            {
                Random rnd = new Random();
                var liste = new List<SORULAR>();
                foreach (var item in exam)
                {
                    liste.Add(item);
                }
                
                int index = rnd.Next(liste.Count);
                questions.Add(liste[index]);
            }
            
            var sinav_id = _DB.exm_question.GroupBy(x=>x.sinav_id).Count();
            if(sinav_id == null)
            {
                sinav_id = 1;
            }
            else
            {
                sinav_id += 1;
            }
            foreach (var item in questions)
            {
                var question = new SINAV_SORULARI();
                question.soru_id = item.soru_id;
                question.sinav_id = sinav_id;   
                _DB.exm_question.Add(question);
                 
            }
            _DB.SaveChanges();
            return View();
        }

        public ActionResult Grade(bool exam_ststus, int exam_id, int user_id)
        {
            var answers = _DB.std_answ.Where(x => x.sinav_id == exam_id && x.kullanici_id == user_id).ToList(); 
            int true_answers = 0;
            int false_answers = 0;

            foreach (var answ in answers)
            {
                var correct_answ = _DB.question.Where(x => x.soru_id == answ.soru_id).FirstOrDefault().soru_cevabi;
                //var sayac=correct_answ == answ.cevap ? true_answers++ : false_answers++;
                if (correct_answ == answ.cevap)
                {
                    true_answers++;
                }
                else
                {
                    false_answers++;
                }
            }

            var result = new SINAV_SONUCLARI();
            result.kullanici_id = user_id;
            result.sinav_id = exam_id;
            result.sinav_tarihi = DateTime.Now;
            result.toplam_dogru_sayisi = true_answers;
            result.toplam_yanlis_sayisi = false_answers;
           
            _DB.exm_result.Add(result);
            _DB.SaveChanges();  
            return View();
        }
    }
}