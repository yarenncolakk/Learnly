using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.ViewModels
{
    public class LessonRequestViewModel
    {
        public int Teacher { get; set; }
       
        public int Topic { get; set; }
        public DateTime LessonDate { get; set; }
    }
}