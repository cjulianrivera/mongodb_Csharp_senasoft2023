using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_senasoft2023.Models
{
    public class Student
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; } = null!;
        [BsonRequired]
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [BsonIgnoreIfNull]
        public DateOnly? BirthDate { get; set; }

        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public string? Phone { get; set; }

        [BsonIgnoreIfNull]
        public string? Address { get; set; }
    }

    public class SimpleStudent
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    
}