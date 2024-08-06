using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
        public ICollection<PrivateLesson> PrivateLessons { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}