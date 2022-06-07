using System;

namespace WebHoTroHocLapTrinh.Data
{
    public class ExerciseDetail
    {
        public Guid IdUser { get; set; }
        public Guid IdExercise { get; set; }
        public bool IsPass { get; set; }
        public int Score { get; set; }

        //relationship
        public User User { get; set; }
        public Exercise Exercise { get; set; }
    }
}
