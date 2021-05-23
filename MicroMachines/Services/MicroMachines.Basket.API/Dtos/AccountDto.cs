using System;

namespace MicroMachines.Basket.API.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public bool IsClosed { get; set; }
    }
}
