using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bc.cores.repositories.Models.Exams.Rels
{
    public class ExamCourseRel
    {
        [ForeignKey(nameof(Exam))]
        [Required]
        public Guid ExamId { get; set; }
        
        [ForeignKey(nameof(Course))]
        [Required]
        public Guid CourseId { get; set; }
    }
}