using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace mongodb_senasoft2023.Models
{
    /*
    definimos el esquema de los estudiantes
    teniendo en cuenta que el id se genera automaticamente en mongoDB
    y los campos obligatorios son el email, el nombre y el apellido
    los demas son opcionales
    */
    public class Student
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string? Id { get; set; }
        
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [BsonIgnoreIfNull]
        public DateOnly? BirthDate { get; set; }

        [BsonIgnoreIfNull]
        public string? Phone { get; set; }

        [BsonIgnoreIfNull]
        public string? Address { get; set; }
    }

    public class SimpleStudent
    {
        public string StudentId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    
}