using MicroMachines.Shopping.API.Dtos;
using System;
using System.Collections.Generic;

namespace MicroMachines.Shopping.API.Queries
{
    public record OrderVm
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RealisationDate { get; set; }
        public Guid BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public Guid? TransactionId { get; set; }
        public string OrderStatus { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}