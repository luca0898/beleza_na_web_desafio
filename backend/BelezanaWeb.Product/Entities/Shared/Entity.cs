using BelezanaWeb.Domain.Contracts.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BelezanaWeb.Domain.Entities.Shared
{
    public class Entity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public bool Deleted { get; set; }
    }
}
