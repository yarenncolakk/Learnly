using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class ExamName
    {
        public int ExamNameId { get; set; }
        public string ExamTitle { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}