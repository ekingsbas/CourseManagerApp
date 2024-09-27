using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CourseManagerApp.Entities;

namespace CourseManagerApp.Data.Configurations
{
    public class CourseConfiguration : BaseConfiguration<Course>, IEntityTypeConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);
            builder.ToTable("Course");

            builder.HasIndex(c => new { c.Subject, c.CourseNumber }).IsUnique();
            builder.Property(c => c.CourseNumber)
                   .HasConversion(
                       v => v.PadLeft(3, '0'), 
                       v => v);


            builder.Property(c => c.Subject)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

        }
    }
}
