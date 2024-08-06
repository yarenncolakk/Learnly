using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.ViewModels
{
    public class LessonListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Lesson { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}