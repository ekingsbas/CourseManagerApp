using CourseManagerApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CourseManagerApp.Data.Configurations
{
    public abstract class BaseConfiguration<Entity> where Entity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
        }
    }
}
