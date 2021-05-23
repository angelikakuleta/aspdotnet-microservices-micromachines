using MicroMachines.Basket.API.Dtos;
using System;
using System.Threading.Tasks;

namespace MicroMachines.Basket.API.Clients
{
    public interface ITransferClient
    {
        Task<AccountDto> GetAccount(Guid accountId);
    }
}
