using MicroMachines.Transfer.API.Data;
using MicroMachines.Transfer.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMachines.Transfer.API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TransferContext _context;

        public AccountRepository(TransferContext context)
        {
            _context = context;
        }

        public async Task<Account> Add(Account entity)
        {
            _context.Accounts.Add(entity);
            await Save();
            return await GetSingle(entity.Id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(entity);
            await Save();
        }

        public async Task Edit(Account entity)
        {
            _context.Accounts.Update(entity);
            await Save();
        }

        public async Task<IEnumerable<Account>> GetByUser(Guid userId)
        {
            return await _context.Accounts
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<Account> GetSingle(Guid id)
        {
            return (await _context.Accounts
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
