using System;

namespace MicroMachines.Transfer.API.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? AccountFromId { get; set; }
        public Guid? AccountToId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public Guid? OrderId { get; set; }
    }
}
