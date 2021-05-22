using System;

namespace MicroMachines.Shopping.API.Dtos
{
    public record OrderItemDto
    {
        public Guid ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
    }
}