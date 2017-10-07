using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.repositories.Models.Exams.Rels
{
    public class ExamCourseRel
    {
        [Key]
        [ForeignKey(nameof(Exam))]
        public Guid ExamId { get; set; }

        [Key]
        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
    }
}