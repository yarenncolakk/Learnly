using LEARNLY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Data.Entity;

namespace LEARNLY.Custom
{
    public class LearnlyContext : DbContext
    {
        public LearnlyContext() : base("name=LearnlyContext")
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<ExamName> ExamNames { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<PrivateLesson> PrivateLessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamQuestion>()
                .HasRequired(eq => eq.ExamName)
                .WithMany(en => en.ExamQuestions)
                .HasForeignKey(eq => eq.ExamId);

            modelBuilder.Entity<ExamQuestion>()
                .HasRequired(eq => eq.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(eq => eq.QuestionId);

            modelBuilder.Entity<ExamResult>()
                .HasRequired(er => er.ExamName)
                .WithMany(en => en.ExamResults)
                .HasForeignKey(er => er.ExamId);

            modelBuilder.Entity<ExamResult>()
                .HasRequired(er => er.User)
                .WithMany(u => u.ExamResults)
                .HasForeignKey(er => er.UserId);

            modelBuilder.Entity<PrivateLesson>()
                .HasRequired(pl => pl.Teacher)
                .WithMany(u => u.PrivateLessonsAsTeacher)
                .HasForeignKey(pl => pl.TeacherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrivateLesson>()
                .HasRequired(pl => pl.Student)
                .WithMany(u => u.PrivateLessonsAsStudent)
                .HasForeignKey(pl => pl.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrivateLesson>()
                .HasRequired(pl => pl.Topic)
                .WithMany(t => t.PrivateLessons)
                .HasForeignKey(pl => pl.TopicId);

            modelBuilder.Entity<Question>()
                .HasRequired(q => q.Branch)
                .WithMany(b => b.Questions)
                .HasForeignKey(q => q.BranchId);

            modelBuilder.Entity<Question>()
                .HasRequired(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId);

            modelBuilder.Entity<StudentAnswer>()
                .HasRequired(sa => sa.User)
                .WithMany(u => u.StudentAnswers)
                .HasForeignKey(sa => sa.UserId);

            modelBuilder.Entity<StudentAnswer>()
                .HasRequired(sa => sa.Question)
                .WithMany(q => q.StudentAnswers)
                .HasForeignKey(sa => sa.QuestionId);

            //modelBuilder.Entity<StudentAnswer>()
            //    .HasOptional(sa => sa.ExamTitle)
            //    .WithMany(en => en.ExamQuestions)
            //    .HasForeignKey(sa => sa.ExamId);

            modelBuilder.Entity<Topic>()
                .HasRequired(t => t.Branch)
                .WithMany(b => b.Topics)
                .HasForeignKey(t => t.BranchId);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasOptional(u => u.Branch)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.BranchId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }

}