using MongoDB.Bson.Serialization.Attributes;

namespace MicroMachines.Catalog.API.Entities
{
    public class Category : Entity
    {
        [BsonRequired]
        public string Name { get; set; }
    }
}
