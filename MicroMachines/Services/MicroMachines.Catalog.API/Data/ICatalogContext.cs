using MicroMachines.Catalog.API.Entities;
using MongoDB.Driver;

namespace MicroMachines.Catalog.API.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<Product> Products { get; }
    }
}
