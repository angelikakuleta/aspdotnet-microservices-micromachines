using MicroMachines.Transfer.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Transfer.API.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetByAccount(Guid accountId);
        Task<Transaction> GetSingle(Guid id);
        Task<Transaction> Add(Transaction entity);
        Task Edit(Transaction entity);
        Task Delete(Guid id);
    }
}
