using MicroMachines.Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Catalog.API.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(Guid id);
        Task Add(T entity);
        Task<bool> Edit(T entity);
        Task<bool> Delete(T entity);
    }
}
