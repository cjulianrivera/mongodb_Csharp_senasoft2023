using mongodb_senasoft2023.Models;
using MongoDB.Driver;

namespace mongodb_senasoft2023.Services
{
    public class CourseService
    {
        private readonly ILogger<CourseService> _logger;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<Course> _courseCollection;

        public CourseService(ILogger<CourseService> logger)
        {
            _logger = logger;
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _courseCollection = _mongoClient.GetDatabase("Senasoft2023").GetCollection<Course>("Courses");
        }
        
        public async Task<List<Course>> GetCourses()
        {
            return await _courseCollection.Find(course => true).ToListAsync();
        }

        public async Task<Course> GetCourse(string id)
        {
            return await _courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Course> CreateCourse(Course course)
        {
            await _courseCollection.InsertOneAsync(course);
            return course;
        }

        public async Task UpdateCourse(string id, Course course)
        {
            await _courseCollection.ReplaceOneAsync(course => course.Id == id, course);
        }

        public async Task AssignCourse(string id, SimpleStudent student)
        {
            var course = await _courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            if (course.Students == null)
            {
                course.Students = new List<SimpleStudent>();
            }

            course.Students.Add(student);
            await _courseCollection.ReplaceOneAsync(course => course.Id == id, course);
        }
    }
}