using MongoDB.Driver;
using mongodb_senasoft2023.Models;

namespace mongodb_senasoft2023.Services
{
    public class StudentService
    {
        private readonly ILogger<StudentService> _logger;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<Student> _studentCollection;

        
        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _studentCollection = _mongoClient.GetDatabase("Senasoft2023").GetCollection<Student>("Students");
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _studentCollection.Find(student => true).ToListAsync();
        }

        public async Task<Student> GetStudent(string id)
        {
            return await _studentCollection.Find(student => student.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await _studentCollection.InsertOneAsync(student);
            return student;
        }

        public async Task UpdateStudent(string id, Student student)
        {
            await _studentCollection.ReplaceOneAsync(student => student.Id == id, student);
        }

        public async Task DeleteStudent(string id)
        {
            await _studentCollection.DeleteOneAsync(student => student.Id == id);
        }
    }
}