using CourseManagerApp.Business.Contracts;
using CourseManagerApp.Data.Contracts;
using CourseManagerApp.Entities;

namespace CourseManagerApp.Business.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(IRepository<Course> repository) : base(repository)
        {
        }

    }
}
