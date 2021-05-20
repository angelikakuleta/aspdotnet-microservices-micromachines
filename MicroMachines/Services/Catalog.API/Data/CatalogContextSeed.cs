using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    internal static class CatalogContextSeed
    {
        internal static void SeedData(CatalogContext catalogContext)
        {
            bool exisProduct = catalogContext.Products.Find(p => true).Any();
            if (!exisProduct)
            {
                catalogContext.Categories.InsertManyAsync(GetSampleCategories());
                catalogContext.Products.InsertManyAsync(GetSampleProducts());
            }
        }

        private static IEnumerable<Category> GetSampleCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("cfdff02f-88e3-4bd1-bcc1-db7e28a4baa0"),
                    Name = "Cars"
                },
                new Category()
                {
                    Id = Guid.Parse("bc63ddd1-f07a-4e26-9ed8-73d633f2e8cb"),
                    Name = "Monster Trucks"
                },
                new Category()
                {
                    Id = Guid.Parse("716c07a4-9c85-4c05-9bd1-47769aa316f4"),
                    Name = "Trains"
                },
                new Category()
                {
                    Id = Guid.Parse("efe4632c-6443-4f32-bc03-b2ca69989ba3"),
                    Name = "Space"
                }
            };
        }

        private static IEnumerable<Product> GetSampleProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = Guid.Parse("0654a8f9-cba6-4ec6-99e1-187d4a6e0a1b"),
                    Name = "Hot Wheels DC Comics Wonder Woman Vehicle",
                    Description = "Entertainment fans will want to collect their favorite Hot Wheels® models reimagined as iconic characters from a rich legacy of entertainment.",
                    Price = 30.00M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("cfdff02f-88e3-4bd1-bcc1-db7e28a4baa0")
                },
                new Product()
                {
                    Id = Guid.Parse("1df7c14f-4025-4133-be79-67b26509eb62"),
                    Name = "Ford GT40",
                    Description = "",
                    Price = 19.95M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("cfdff02f-88e3-4bd1-bcc1-db7e28a4baa0")
                },
                new Product()
                {
                    Id = Guid.Parse("e36e7f4b-0525-4072-89e0-bc0c98c9980e"),
                    Name = "Hasbro Corvette - rare",
                    Description = "",
                    Price = 17.88M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("cfdff02f-88e3-4bd1-bcc1-db7e28a4baa0")
                },
                new Product()
                {
                    Id = Guid.Parse("59edcce9-9002-4e1e-b120-d8122c5ba25d"),
                    Name = "Monster Trucks Tiger Shark",
                    Description = "The Hot Wheels Monster Trucks 1:24 scale die-cast trucks are THE baddest trucks ever built for competition and ultimate dominance! ",
                    Price = 12.50M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("bc63ddd1-f07a-4e26-9ed8-73d633f2e8cb")
                },
                new Product()
                {
                    Id = Guid.Parse("687535e5-45fa-4ced-b314-2216f3da1590"),
                    Name = "Pickup",
                    Description = "",
                    Price = 42.20M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("cfdff02f-88e3-4bd1-bcc1-db7e28a4baa0")
                },
                new Product()
                {
                    Id = Guid.Parse("815e559f-9d70-45e5-9c3a-20a4453df25c"),
                    Name = "Monster Trucks Test Subject",
                    Description = "Outrageous assortment of 1:24 scale Hot Wheels Monster Trucks with durable die-cast metal bodies!",
                    Price = 39.00M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("bc63ddd1-f07a-4e26-9ed8-73d633f2e8cb")
                },
                new Product()
                {
                    Id = Guid.Parse("2e3d21ca-7d6b-4740-961d-dffd68664cc7"),
                    Name = "Monster Trucks 1970 Dodge Charger",
                    Description = "",
                    Price = 11.99M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("bc63ddd1-f07a-4e26-9ed8-73d633f2e8cb")
                },
                new Product()
                {
                    Id = Guid.Parse("20736b78-f009-4135-a856-29a978eaeb78"),
                    Name = "Caboose",
                    Description = "",
                    Price = 20.00M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("716c07a4-9c85-4c05-9bd1-47769aa316f4")
                },
                new Product()
                {
                    Id = Guid.Parse("921fc5f8-674f-4b37-903e-a646d961728b"),
                    Name = "Star Destroyer",
                    Description = "The Star Destroyer is a dagger-shaped type of capital ship that is used by the Galactic Republic, the Galactic Empire, and the First Order.",
                    Price = 15.00M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("efe4632c-6443-4f32-bc03-b2ca69989ba3")
                },
                new Product()
                {
                    Id = Guid.Parse("cfc0dfb6-13e5-4ce4-95cb-612ce2c24d9d"),
                    Name = "Apollo CSM",
                    Description = "The Apollo command and service module (CSM) was one of two principal components of the United States Apollo spacecraft, used for the Apollo program, which landed astronauts on the Moon between 1969 and 1972. The CSM functioned as a mother ship, which carried a crew of three astronauts and the second Apollo spacecraft, the lunar module, to lunar orbit, and brought the astronauts back to Earth.",
                    Price = 14.50M,
                    AvailableStock = 60,
                    CategoryId = Guid.Parse("efe4632c-6443-4f32-bc03-b2ca69989ba3")
                }
            };
        }
    }
}