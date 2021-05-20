using MicroMachines.Catalog.API.Data;
using MicroMachines.Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Catalog.API.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
            : base(context.Products)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetByCategory(Guid categoryId)
        {
            return await _context.Products
                .Find(x => x.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
