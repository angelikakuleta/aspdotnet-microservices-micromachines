using MicroMachines.Basket.API.Entities;
using System;
using System.Threading.Tasks;

namespace MicroMachines.Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetSingle(Guid userId);
        Task<ShoppingCart> Edit(ShoppingCart basket);
        Task Delete(Guid userId);
    }
}
