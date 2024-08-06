using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public int BranchId { get; set; }
        public int TopicId { get; set; }
        public string Answer { get; set; }

        public Branch Branch { get; set; }
        public Topic Topic { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }

}