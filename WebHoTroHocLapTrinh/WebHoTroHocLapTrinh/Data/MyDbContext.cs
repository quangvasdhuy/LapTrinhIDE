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
        #endregion

    }
}
