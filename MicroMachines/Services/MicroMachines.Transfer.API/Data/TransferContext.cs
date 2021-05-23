using MicroMachines.Transfer.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MicroMachines.Transfer.API.Data
{
    public class TransferContext : DbContext
    {
        public TransferContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
