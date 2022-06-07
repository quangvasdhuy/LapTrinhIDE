using Microsoft.EntityFrameworkCore;

namespace WebHoTroHocLapTrinh.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        
            #region DbSet
            public DbSet<Exercise> Exercises { get; set; }
            public DbSet<Chapter> Chapters { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<ExerciseDetail> ExerciseDetails { get; set; }
        #endregion
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(us => us.IdUser);
            });

            modelBuilder.Entity<ExerciseDetail>(entity =>
            {
                entity.ToTable("ExerciseDetail");
                entity.HasKey(e => new { e.IdUser, e.IdExercise });

                entity.HasOne(e => e.User)
                    .WithMany(e => e.ExerciseDetails)
                    .HasForeignKey(e => e.IdUser)
                    .HasConstraintName("FK_ExerciseDetail_User");

                entity.HasOne(e => e.Exercise)
                    .WithMany(e => e.ExerciseDetails)
                    .HasForeignKey(e => e.IdExercise)
                    .HasConstraintName("FK_ExerciseDetail_Exercise");
            });
            }
    }
}
