using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.repositories.Models.Exams.Scores
{
    public class UserExam
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [ForeignKey("AspNetUsers")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Exam))]
        [Required]
        public Guid ExamId { get; set; }

        [Required]
        public long CreatedAt { get; set; }

        public double Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int TotalAnswers { get; set; }
    }

    public class UserCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("AspNetUsers")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Course))]
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public long CreatedAt { get; set; }

        public double Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int TotalAnswers { get; set; }
    }

    public class UserExamAnswer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("AspNetUsers")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Exam))]
        [Required]
        public Guid ExamId { get; set; }
        
        [ForeignKey(nameof(Question))]
        [Required]
        public Guid QuestionId { get; set; }

        [ForeignKey(nameof(Answer))]
        [Required]
        public Guid AnswerId { get; set; }
        
        public bool IsCorrect { get; set; }
    }

    public class UserCourseAnswer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("AspNetUsers")]
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Course))]
        [Required]
        public Guid CourseId { get; set; }

        [ForeignKey(nameof(Question))]
        [Required]
        public Guid QuestionId { get; set; }

        [ForeignKey(nameof(Answer))]
        [Required]
        public Guid AnswerId { get; set; }

        public bool IsCorrect { get; set; }
    }
}
