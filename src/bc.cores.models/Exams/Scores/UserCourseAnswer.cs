using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.models.Exams.Scores
{
    public class UserCourseAnswer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(UserCourse))]
        [Required]
        public Guid UserCourseId { get; set; }

        [ForeignKey(nameof(Question))]
        [Required]
        public Guid QuestionId { get; set; }

        [ForeignKey(nameof(Answer))]
        [Required]
        public Guid AnswerId { get; set; }

        public bool IsCorrect { get; set; }
    }
}