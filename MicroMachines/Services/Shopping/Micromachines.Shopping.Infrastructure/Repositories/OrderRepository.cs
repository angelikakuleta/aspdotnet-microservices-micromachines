using Microsoft.EntityFrameworkCore;
using MicroMachines.Shopping.Domain.Entities;
using MicroMachines.Shopping.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroMachines.MicroMachines.Shopping.Domain.Interfaces;

namespace MicroMachines.Shopping.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll(Expression<Func<Order, bool>> condition)
        {
            return await _context.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderItems)
                .AsNoTracking()
                .Where(condition)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByUser(Guid userId)
        {
            return await _context.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderItems)
                .AsNoTracking()
                .Where(x => x.BuyerId == userId)
                .ToListAsync();
        }

        public async Task<Order> GetSingle(Guid id)
        {
            return (await _context.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderItems)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync())
                .FirstOrDefault();
        }

        public async Task<Order> Add(Order entity)
        {
            _context.Orders.Add(entity);
            await Save();
            return await GetSingle(entity.Id);
        }

        public async Task Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            await Save();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
