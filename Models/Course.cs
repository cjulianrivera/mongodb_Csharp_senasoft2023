using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_senasoft2023.Models
{
    public class Course
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public List<SimpleStudent>? Students { get; set; }
    }
}