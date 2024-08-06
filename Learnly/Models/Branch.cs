using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<User> Users { get; set; }
    }
}