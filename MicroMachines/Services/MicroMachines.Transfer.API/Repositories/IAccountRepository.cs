using MicroMachines.Transfer.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Transfer.API.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetByUser(Guid userId);
        Task<Account> GetSingle(Guid id);
        Task<Account> Add(Account entity);
        Task Edit(Account entity);
        Task Delete(Guid id);
    }
}
