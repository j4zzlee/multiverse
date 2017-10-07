using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bc.cores.repositories.Enums;

namespace bc.cores.repositories.Models.Exams.Scores
{
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

        public int ExamType { get; set; }
        [NotMapped]
        public ExamType ExamTypeEnum
        {
            get => (ExamType)ExamType;
            set => ExamType = (int)value;
        }
    }
}