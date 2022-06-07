using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebHoTroHocLapTrinh.Data
{   
    [Table("Chapter")]
    public class Chapter
    {
        [Key]
        public Guid IdChapter { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameChapter { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public Guid? IdSubject { get; set; }
        [ForeignKey("IdSubject")]
        public Subject Subject { get; set; }

    }
}
