using MicroMachines.Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Catalog.API.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(Guid categoryId);
    }
}
