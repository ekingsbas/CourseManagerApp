using CourseManagerApp.Data.Configurations;
using CourseManagerApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagerApp.Data
{
    public class DatabaseContext : DbContext
    {

        private readonly string cnString;
        public DatabaseContext(string connString)
        {

            cnString = connString;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(cnString);
        }

        public DbSet<Course> Course { get; set; }
    }
}
