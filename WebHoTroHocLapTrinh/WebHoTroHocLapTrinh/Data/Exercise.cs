using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebHoTroHocLapTrinh.Data
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public Guid IdExercise { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameExercise { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string ApiRapid { get; set; }
        public string Diffculty { get; set; }
        public string Image { get; set; }
        public Guid? IdChapter { get; set; }
        [ForeignKey("IdChapter")]
        public Chapter Chapter { get; set; }
        public ICollection<ExerciseDetail> ExerciseDetails { get; set; }

        public Exercise()
        {
            ExerciseDetails = new List<ExerciseDetail>();
        }
    }
}
