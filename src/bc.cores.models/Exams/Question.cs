using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bc.cores.models.Enums;

namespace bc.cores.models.Exams
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
        public QuestionDisplayType DisplayTypeEnum
        {
            get => (QuestionDisplayType)DisplayType;
            set => DisplayType = (int)value;
        }

        public int QuestionType { get; set; }

        [NotMapped]
        public QuestionType QuestionTypeEnum
        {
            get => (QuestionType)QuestionType;
            set => QuestionType = (int)value;
        }

        public int Visibility { get; set; }

        [NotMapped]
        public Visibility VisibilityEnum
        {
            get => (Visibility)Visibility;
            set => Visibility = (int)value;
        }
    }
}
