using Microsoft.EntityFrameworkCore;
using SchoolDigital.Core;
using SchoolDigital.Core.Entities;


namespace SchoolDigital
{
    public class DataContext:DbContext
    {
        public DbSet<Lesson> lessons { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Attendance> attendanceList { get; set; }
        public DbSet<Material> materialsList { get; set; }
        public override void OnConFiguruing(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=")
        }

    }
}


