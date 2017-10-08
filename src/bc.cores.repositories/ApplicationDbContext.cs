using System;
using bc.cores.repositories.Models;
using bc.cores.repositories.Models.Exams;
using bc.cores.repositories.Models.Exams.Rels;
using bc.cores.repositories.Models.Exams.Scores;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bc.cores.repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(b =>
            {
                b.Property(u => u.Id)
                    .HasDefaultValueSql("newsequentialid()");
            });

            builder.Entity<ApplicationRole>(b =>
            {
                b.Property(u => u.Id)
                    .HasDefaultValueSql("newsequentialid()");
            });

            #region Exams
            builder.Entity<Exam>();
            builder.Entity<Course>();
            builder.Entity<Question>();
            builder.Entity<Answer>();
            builder.Entity<Photo>();
            builder.Entity<Audio>();
            builder.Entity<Video>();

            // Relationships
            builder.Entity<ExamCourseRel>(b =>
            {
                b.HasKey(ecr => new { ecr.ExamId, ecr.CourseId });
            });
            builder.Entity<ExamQuestionRel>(b =>
            {
                b.HasKey(ecr => new { ecr.ExamId, ecr.QuestionId });
            });
            builder.Entity<UserCourse>(b =>
            {
                b.HasIndex(uc => new { uc.UserId, uc.CourseId, uc.CreatedAt});
            });
            builder.Entity<UserExam>(b =>
            {
                b.HasIndex(ue => new { ue.UserId, ue.ExamId, ue.CreatedAt });
            });

            builder.Entity<UserCourseAnswer>();
            builder.Entity<UserExamAnswer>();
            #endregion
        }
    }
}
