using System;
using System.Collections.Generic;

namespace WebHoTroHocLapTrinh.Data
{
    public class User
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfStudent { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<ExerciseDetail> ExerciseDetails { get; set; }

        public User()
        {
            ExerciseDetails = new List<ExerciseDetail>();
        }
    }
}
