using MicroMachines.Transfer.API.Data;
using MicroMachines.Transfer.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMachines.Transfer.API.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransferContext _context;

        public TransactionRepository(TransferContext context)
        {
            _context = context;
        }

        public async Task<Transaction> Add(Transaction entity)
        {
            _context.Transactions.Add(entity);
            await Save();
            return await GetSingle(entity.Id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(entity);
            await Save();
        }

        public async Task Edit(Transaction entity)
        {
            _context.Transactions.Update(entity);
            await Save();
        }

        public async Task<IEnumerable<Transaction>> GetByAccount(Guid accountId)
        {
            return await _context.Transactions
                .AsNoTracking()
                .Where(x => x.AccountFromId == accountId || x.AccountToId == accountId)
                .ToListAsync();
        }

        public async Task<Transaction> GetSingle(Guid id)
        {
            return (await _context.Transactions
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync())
                .FirstOrDefault();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
