using CourseManagerApp.Entities;

namespace CourseManagerApp.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        private DatabaseContext Context
        {
            get { return _context as DatabaseContext; }
        }

        public CourseRepository()
        {
        }

        public CourseRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
