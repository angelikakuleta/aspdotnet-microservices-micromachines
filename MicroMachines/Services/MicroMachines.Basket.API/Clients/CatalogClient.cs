using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MicroMachines.Basket.API.Clients
{
    public class CatalogClient : ICatalogClient
    {
        private readonly HttpClient httpClient;

        public CatalogClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> GetProductAvailableStock(Guid productId)
        {
            return await httpClient.GetFromJsonAsync<int>($"/api/catalog/products/{productId}/stock");
        }
    }
}
