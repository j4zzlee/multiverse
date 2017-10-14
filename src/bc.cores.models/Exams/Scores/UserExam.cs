using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bc.cores.models.Enums;

namespace bc.cores.models.Exams.Scores
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

        public int ExamType { get; set; }

        [NotMapped]
        public ExamType ExamTypeEnum
        {
            get => (ExamType) ExamType;
            set => ExamType = (int) value;
        }
    }
}
