using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.repositories.Models.Exams.Rels
{
    public class ExamQuestionRel
    {
        [Key]
        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }

        [Key]
        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }
    }
}