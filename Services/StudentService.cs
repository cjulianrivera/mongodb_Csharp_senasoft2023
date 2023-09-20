using MongoDB.Driver;
using mongodb_senasoft2023.Models;

namespace mongodb_senasoft2023.Services
{
    /*
    definimos los metodos que vamos a utilizar desde el controlador
    para manejar los estudiantes
    */
    public class StudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly IMongoCollection<Student> _studentCollection;
        private readonly ConnectionService _connectionService;

        
        public StudentService(ILogger<StudentService> logger,
                              ConnectionService connectionService)
        {
            _logger = logger;
            _connectionService = connectionService;
            _studentCollection = _connectionService._studentCollection;
        }

        //obtenemos todos los estudiantes
        public async Task<List<Student>> GetStudents()
        {
            return await _studentCollection.Find(student => true).ToListAsync();
        }

        //obtenemos un estudiante por su id
        public async Task<Student> GetStudent(string id)
        {
            return await _studentCollection.Find(student => student.Id == id).FirstOrDefaultAsync();
        }

        //creamos un nuevo estudiante
        public async Task<Student> CreateStudent(Student student)
        {
            await _studentCollection.InsertOneAsync(student);
            return student;
        }

        //actualizamos un estudiante
        public async Task<Student> UpdateStudent(string id, Student student)
        {
            if (student.Id == null)
                student.Id = id;
            await _studentCollection.FindOneAndReplaceAsync(student => student.Id == id, student);
            return student;
        }

        //eliminamos un estudiante
        public async Task DeleteStudent(string id)
        {
            await _studentCollection.DeleteOneAsync(student => student.Id == id);
        }
    }
}