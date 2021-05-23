using System;
using System.Threading.Tasks;

namespace MicroMachines.Basket.API.Clients
{
    public interface ICatalogClient
    {
        Task<int> GetProductAvailableStock(Guid productId);
    }
}