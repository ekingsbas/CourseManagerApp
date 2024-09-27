namespace CourseManagerApp.Entities
{
    public class Course : BaseEntity
    {
        public string Subject { get; set; }
        public string CourseNumber { get; set; }
        public string Description { get; set; }
    }
}
