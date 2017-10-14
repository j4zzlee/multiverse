using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bc.cores.models.Enums;

namespace bc.cores.models.Exams
{
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Question))]
        [Required]
        public Guid QuestionId { get; set; }

        [ForeignKey(nameof(Photo))]
        public Guid? PhotoId { get; set; }

        [ForeignKey(nameof(Audio))]
        public Guid? SoundId { get; set; }
        
        public string Value { get; set; }

        public int DisplayType { get; set; }

        [NotMapped]
        public AnswerDisplayType DisplayTypeEnum
        {
            get => (AnswerDisplayType)DisplayType;
            set => DisplayType = (int) value;
        }
    }
}
