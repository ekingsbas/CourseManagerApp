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

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CourseConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer(cnString);
            }
        }

        public DbSet<Course> Course { get; set; }
    }
}
