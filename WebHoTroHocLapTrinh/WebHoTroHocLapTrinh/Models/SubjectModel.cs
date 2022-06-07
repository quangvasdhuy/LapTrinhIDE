using System;
using System.ComponentModel.DataAnnotations;

namespace WebHoTroHocLapTrinh.Models
{
    public class SubjectModel 
    {
        
        [Required]
        [MaxLength(50)]
        public string NameSubject { get; set; }
    }
}
