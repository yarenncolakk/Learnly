using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public int TotalCorrectCount { get; set; }
        public int TotalIncorrectCount { get; set; }
        public DateTime ExamDate { get; set; }

        public ExamName ExamName { get; set; }
        public User User { get; set; }
    }
}