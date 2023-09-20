using mongodb_senasoft2023.Models;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

namespace mongodb_senasoft2023.Services
{
    /*
    definimos los metodos que vamos a utilizar desde el controlador
    para manejar los cursos
    */
    public class CourseService
    {
        private readonly ILogger<CourseService> _logger;
        
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly StudentService _studentService;
        private readonly ConnectionService _connectionService;

        public CourseService(ILogger<CourseService> logger,
                             StudentService studentService,
                             ConnectionService connectionService)
        {
            _logger = logger;
            _studentService = studentService;
            _connectionService = connectionService;
            _courseCollection = _connectionService._courseCollection;
        }

        //obtenemos todos los cursos  
        public async Task<List<Course>> GetCourses()
        {
            return await _courseCollection.Find(course => true).ToListAsync();
        }

        //obtenemos un curso por su id
        public async Task<Course> GetCourse(string id)
        {
            return await _courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();
        }

        //creamos un nuevo curso
        public async Task<Course> CreateCourse(Course course)
        {
            await _courseCollection.InsertOneAsync(course);
            return course;
        }


        /*
        asignamos un estudiante a un curso
        para esto recibimos el id del curso y el id del estudiante
        validamos que el curso y el estudiante existan
        y que el estudiante no este ya en el curso
        en el arreglo de estudiantes agregamos una version reducida del estudiante
        solo con los datos necesarios
        */
        public async Task<Course> AssignCourse(string id, string studentId)
        {
            Course? course = await _courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();
            if (course == null)
                throw new Exception("Course not found");

            Student? student = await _studentService.GetStudent(studentId);
            if (student == null)
                throw new Exception("Student not found");

            if (course.Students == null)
                course.Students = new List<SimpleStudent>();

            SimpleStudent? studentAlreadyInCourse = course.Students.Find(s => s.StudentId == studentId);
            if (studentAlreadyInCourse != null)
                throw new Exception("Student already in course");

            SimpleStudent studentInCourse = new SimpleStudent {
                StudentId = student.Id!,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email
            };
            
            course.Students.Add(studentInCourse);
            await _courseCollection.ReplaceOneAsync(course => course.Id == id, course);
            return course;
        }
    }
}