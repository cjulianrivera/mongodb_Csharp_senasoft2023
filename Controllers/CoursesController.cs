using Microsoft.AspNetCore.Mvc;
using mongodb_senasoft2023.Models;
using mongodb_senasoft2023.Services;

namespace mongodb_senasoft2023.Controllers
{
    /*
    definimos los metodos expuestos en el controlador de cursos
    */
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly CourseService _courseService;

        public CoursesController(ILogger<CoursesController> logger, 
                                CourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        //obtenemos todos los cursos
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            try
            {
                return await _courseService.GetCourses();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting courses: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        //obtenemos un curso por su id
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(string id)
        {
            try
            {
                Course? course = await _courseService.GetCourse(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting course with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            
        }

        //creamos un nuevo curso
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            try
            {
                Course? createdCourse = await _courseService.CreateCourse(course);
                return Ok(createdCourse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating course: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /*
        asignamos un estudiante a un curso
        para esto recibimos el id del curso y el id del estudiante
        el id del curso lo recibimos como parametro de la ruta
        el id del estudiate lo recibimos como parametro de la consulta
        */
        [HttpPatch("{id}")]
        public async Task<ActionResult> AssignCourse(string id, string studentId)
        {
            try
            {
                await _courseService.AssignCourse(id, studentId);
                Course course = await _courseService.GetCourse(id);
                return Ok(course);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error assinging course: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}