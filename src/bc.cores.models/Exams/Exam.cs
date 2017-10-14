using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bc.cores.models.Enums;

namespace bc.cores.models.Exams
{
    public class Exam
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Visibility { get; set; }

        public int? MaxQuestionsToPlay { get; set; }

        [NotMapped]
        public Visibility VisibilityEnum
        {
            get => (Visibility)Visibility;
            set => Visibility = (int)value;
        }

        [ForeignKey("AspNetUsers")]
        public Guid CreatedById { get; set; }

        [Required]
        public long CreatedAt { get; set; }
    }
}
