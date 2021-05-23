using MicroMachines.Basket.API.Entities;
using MicroMachines.EventBus.RabbitMQ;
using System;
using System.Collections.Generic;

namespace MicroMachines.Basket.API.Events
{
    public class BasketCheckoutAcceptedEvent : Event
    {
        public Guid UserId { get; set; }
        public string FistName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
        public Guid AccountFromId { get; init; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
