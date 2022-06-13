using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebHoTroHocLapTrinh.Data;

namespace WebHoTroHocLapTrinh.Models
{
    public class ExerciseModel
    {
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
      
        //public Chapter Chapter { get; set; }
    }
}
