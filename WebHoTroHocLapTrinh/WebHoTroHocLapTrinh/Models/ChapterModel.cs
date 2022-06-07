using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebHoTroHocLapTrinh.Data;

namespace WebHoTroHocLapTrinh.Models
{
    public class ChapterModel
    {
        [Required]
        [MaxLength(100)]
        public string NameChapter { get; set; }
        [Required]
        public Guid? IdSubject { get; set; }
        //public Subject Subject { get; set; }
    }
}
