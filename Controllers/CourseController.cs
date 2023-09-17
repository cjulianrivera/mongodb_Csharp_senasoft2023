using Microsoft.AspNetCore.Mvc;
using mongodb_senasoft2023.Models;
using mongodb_senasoft2023.Services;

namespace mongodb_senasoft2023.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly CourseService _courseService;

        public CourseController(ILogger<CourseController> logger, 
                                CourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            return await _courseService.GetCourses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(string id)
        {
            return await _courseService.GetCourse(id);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            return await _courseService.CreateCourse(course);
        }

        [HttpPost("{id}/assign")]
        public async Task<ActionResult> AssignCourse(string id, SimpleStudent student)
        {
            await _courseService.AssignCourse(id, student);
            return NoContent();
        }
        
    }
}