using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MicroMachines.Catalog.API.Entities
{
    public class Product : Entity
    {
        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("category_id")]
        public Guid CategoryId { get; set; }

        [BsonIgnoreIfNull]
        public string Description { get; set; }

        [BsonIgnoreIfNull]
        public string ImageFile { get; set; }

        [BsonRequired]
        public decimal Price { get; set; }

        [BsonDefaultValue(0)]
        public int AvailableStock { get; set; }
    }
}
