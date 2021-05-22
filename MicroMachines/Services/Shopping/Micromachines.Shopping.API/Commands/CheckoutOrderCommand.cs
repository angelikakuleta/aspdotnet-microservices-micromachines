using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MicroMachines.Shopping.API.Commands
{
    public class CheckoutOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; init; }
        public string FistName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
        public Guid AccountId { get; init; }
        public IEnumerable<CheckoutOrderItemDto> OrderItems { get; set; }

        public decimal TotalPrice => OrderItems.Sum(x => x.UnitPrice * x.Quantity);
    }

    public record CheckoutOrderItemDto
    {
        public Guid ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal UnitPrice { get; init; }
        public int Quantity { get; init; }
    }
}
