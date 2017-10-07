using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using bc.cores.repositories.Enums;

namespace bc.cores.repositories.Models.Exams
{
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Course))]
        [Required]
        public Guid CourseId { get; set; }

        [ForeignKey(nameof(Photo))]
        public Guid? PhotoId { get; set; }

        [ForeignKey(nameof(Audio))]
        public Guid? SoundId { get; set; }

        [ForeignKey(nameof(Video))]
        public Guid? VideoId { get; set; }
        
        public string Value { get; set; }

        public int DisplayType { get; set; }

        [NotMapped]
        public QuestionDisplayType DisplayTypeEnum => (QuestionDisplayType)DisplayType;

        public int QuestionType { get; set; }

        [NotMapped]
        public QuestionType QuestionTypeEnum => (QuestionType)DisplayType;

        public int Visibility { get; set; }

        [NotMapped]
        public Visibility VisibilityEnum => (Visibility)Visibility;
    }
}
