using System;
using System.ComponentModel.DataAnnotations;

namespace WebHoTroHocLapTrinh.Models
{
    public class UserModel 
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfStudent { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }

    }
}
