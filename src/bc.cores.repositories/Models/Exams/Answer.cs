using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using bc.cores.repositories.Enums;

namespace bc.cores.repositories.Models.Exams
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
        public AnswerDisplayType DisplayTypeEnum => (AnswerDisplayType) DisplayType;
    }
}
