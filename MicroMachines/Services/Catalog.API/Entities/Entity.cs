using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Catalog.API.Entities
{
    public class Entity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
