using mongodb_senasoft2023.Models;
using MongoDB.Driver;

namespace mongodb_senasoft2023.Services
{
    /*
    metodo general para gestionar la conexion hacia mongoDB
    */
    public class ConnectionService
    {
        private readonly ILogger<ConnectionService> _logger;
        public readonly IMongoCollection<Student> _studentCollection;
        public readonly IMongoCollection<Course> _courseCollection;

        public ConnectionService(ILogger<ConnectionService> logger)
        {
            _logger = logger;
            MongoClient mongoClient = new MongoClient("mongodb+srv://");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("Senasoft2023cs");
            _studentCollection = mongoDatabase.GetCollection<Student>("Students");
            _courseCollection = mongoDatabase.GetCollection<Course>("Courses");
        }
    }
}