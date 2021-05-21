using MicroMachines.Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroMachines.MicroMachines.Shopping.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll(Expression<Func<Order, bool>> condition);
        Task<IEnumerable<Order>> GetByUser(Guid userId);
        Task<Order> GetSingle(Guid id);
        Task<Order> Add(Order entity);
        Task Delete(Order entity);
    }
}
