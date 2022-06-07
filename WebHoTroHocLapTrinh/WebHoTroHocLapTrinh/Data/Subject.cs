using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebHoTroHocLapTrinh.Data
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public Guid IdSubject { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameSubject { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
