using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.models.Exams.Rels
{
    public class ExamQuestionRel
    {
        [Required]
        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }

        [Required]
        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
    }
}