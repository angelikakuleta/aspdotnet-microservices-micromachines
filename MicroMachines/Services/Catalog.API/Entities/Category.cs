using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Category : Entity
    {
        [BsonRequired]
        public string Name { get; set; }
    }
}
