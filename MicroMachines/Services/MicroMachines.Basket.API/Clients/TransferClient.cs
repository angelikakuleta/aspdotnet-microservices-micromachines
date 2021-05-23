using MicroMachines.Basket.API.Dtos;
using System;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroMachines.Basket.API.Clients
{
    public class TransferClient : ITransferClient
    {
        private readonly HttpClient httpClient;

        public TransferClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AccountDto> GetAccount(Guid accountId)
        {
            return await httpClient.GetFromJsonAsync<AccountDto>($"/api/accounts/{accountId}");
        }
    }
}
