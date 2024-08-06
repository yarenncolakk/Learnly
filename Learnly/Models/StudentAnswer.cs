using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public int? ExamId { get; set; }

        public User User { get; set; }
        public Question Question { get; set; }
        //public ExamName ExamTitle { get; set; }
    }

}