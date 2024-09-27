using CourseManagerApp.Business.Contracts;
using CourseManagerApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            var createdCourse = await _courseService.AddAsync(course);
            return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.ID }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.ID)
            {
                return BadRequest();
            }

            await _courseService.UpdateAsync(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
