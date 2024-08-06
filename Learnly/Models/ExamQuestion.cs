using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class ExamQuestion
    {
        public int ExamQuestionId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }

        public ExamName ExamName { get; set; }
        public Question Question { get; set; }
    }
}