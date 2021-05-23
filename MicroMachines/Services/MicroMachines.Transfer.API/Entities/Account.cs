using System;

namespace MicroMachines.Transfer.API.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public bool IsClosed { get; set; }
    }
}
