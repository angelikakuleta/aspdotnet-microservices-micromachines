using System;
using System.Threading.Tasks;

namespace MicroMachines.Catalog.API.Clients
{
    public interface ICatalogClient
    {
        Task<int> GetProductAvailableStock(Guid productId);
    }
}