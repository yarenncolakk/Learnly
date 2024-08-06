using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEARNLY.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? BranchId { get; set; }
        public Role Role { get; set; }
        public Branch Branch { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
        public ICollection<PrivateLesson> PrivateLessonsAsTeacher { get; set; }
        public ICollection<PrivateLesson> PrivateLessonsAsStudent { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}