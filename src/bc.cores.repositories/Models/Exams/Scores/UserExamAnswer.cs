using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.repositories.Models.Exams.Scores
{
    public class UserExamAnswer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [ForeignKey(nameof(UserExam))]
        [Required]
        public Guid UserExamId { get; set; }
        
        [ForeignKey(nameof(Question))]
        [Required]
        public Guid QuestionId { get; set; }

        [ForeignKey(nameof(Answer))]
        [Required]
        public Guid AnswerId { get; set; }
        
        public bool IsCorrect { get; set; }
    }
}