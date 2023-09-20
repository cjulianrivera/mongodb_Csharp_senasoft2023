using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mongodb_senasoft2023.Models;
using mongodb_senasoft2023.Services;

namespace mongodb_Csharp_senasoft2023.Controllers
{
    /*
    definimos los metodos expuestos en el controlador de estudiantes
    */
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger,
                                 StudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        //obtenemos todos los estudiantes
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents() 
        {
            try
            {
                var students = await _studentService.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting students: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //obtenemos un estudiante por su id
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            try
            {
                var student = await _studentService.GetStudent(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting student with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //creamos un nuevo estudiante
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                Student createdStudent = await _studentService.CreateStudent(student);
                return Ok(createdStudent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating student: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //actualizamos un estudiante
        [HttpPatch("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(string id, Student student)
        {
            try
            {
                Student updatedStudent = await _studentService.UpdateStudent(id, student);
                if (updatedStudent == null)
                {
                    return NotFound();
                }
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating student with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //eliminamos un estudiante
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(string id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting student with id {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}