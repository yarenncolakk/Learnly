using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class PrivateLesson
    {
        public int PrivateLessonId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public int TopicId { get; set; }
        public DateTime PrivateLessonDate { get; set; }
        public bool Status { get; set; }

        public User Teacher { get; set; }
        public User Student { get; set; }
        public Topic Topic { get; set; }
    }
}