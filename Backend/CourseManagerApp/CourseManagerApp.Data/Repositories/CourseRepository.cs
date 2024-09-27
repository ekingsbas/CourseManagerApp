using CourseManagerApp.Data.Contracts;
using CourseManagerApp.Entities;

namespace CourseManagerApp.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private DatabaseContext Context
        {
            get { return _context as DatabaseContext; }
        }

        //public CourseRepository()
        //{
        //}

        public CourseRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
