using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace FJU.Inventario.Domain.Entities
{
    public class TEntity
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string? Id { get; set; }
    }
}
