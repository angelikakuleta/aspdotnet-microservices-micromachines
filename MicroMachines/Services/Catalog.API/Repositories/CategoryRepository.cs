using Catalog.API.Data;
using Catalog.API.Entities;
using System;

namespace Catalog.API.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ICatalogContext _context;

        public CategoryRepository(ICatalogContext context)
            : base(context.Categories)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
