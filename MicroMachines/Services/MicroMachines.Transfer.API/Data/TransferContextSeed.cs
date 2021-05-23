using MicroMachines.Transfer.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMachines.Transfer.API.Data
{
    public class TransferContextSeed
    {
        public static async Task SeedAsync(TransferContext transferContext)
        {
            if (!transferContext.Accounts.Any())
            {
                transferContext.Accounts.AddRange(GetSampleAccounts());
                transferContext.Transactions.AddRange(GetSampleTransactions());
                await transferContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Account> GetSampleAccounts()
        {
            return new List<Account>
            {
                new Account()
                {
                    Id = Guid.Parse("5d4392b6-9a5a-4cee-8f89-37330b9bb47c"),
                    UserId = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43"),
                    Balance = 0,
                    IsClosed = true
                },
                new Account()
                {
                    Id = Guid.Parse("5d4392b6-9a5a-4cee-8f89-37330b9bb47c"),
                    UserId = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43"),
                    Balance = 320.40M,
                    IsClosed = false
                }
            };
        }

        private static IEnumerable<Transaction> GetSampleTransactions()
        {
            return new List<Transaction>
            {
                new Transaction()
                {
                    Id = Guid.Parse("5d4392b6-9a5a-4cee-8f89-37330b9bb47c"),
                    AccountFromId = Guid.Parse("5d4392b6-9a5a-4cee-8f89-37330b9bb47c"),
                    Amount = 55.00M,
                    TimeStamp = DateTime.Now,
                    Status = TransactionStatus.Confirmed,
                    Type = TransactionType.OrderPayment,
                    OrderId = Guid.Parse("05559eb9-3653-4587-9b71-90953ef41d43")
                }
            };
        }
    }
}
