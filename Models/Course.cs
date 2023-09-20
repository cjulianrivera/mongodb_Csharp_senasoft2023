using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace mongodb_senasoft2023.Models
{
    /*
    definimos el esquema de los cursos
    teniendo en cuenta que el id se genera automaticamente en mongoDB
    y los campos obligatorios son el codigo y el nombre
    los estidiantes son opcionales y se van agregan una vez se cree el curso
    */
    public class Course
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string? Id { get; set; }

        [Required]
        public string Code { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        public List<SimpleStudent>? Students { get; set; }
    }
}