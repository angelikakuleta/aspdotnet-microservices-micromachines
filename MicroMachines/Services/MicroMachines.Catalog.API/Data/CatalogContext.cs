using MicroMachines.Catalog.API.Entities;
using MongoDB.Driver;

namespace MicroMachines.Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Categories = database.GetCollection<Category>(nameof(Categories));
            Products = database.GetCollection<Product>(nameof(Products));
           
            CatalogContextSeed.SeedData(this);
        }

        public IMongoCollection<Category> Categories { get; }
        public IMongoCollection<Product> Products { get; }
    }
}
