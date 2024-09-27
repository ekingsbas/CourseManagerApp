using System.ComponentModel.DataAnnotations;

namespace CourseManagerApp.Entities
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
