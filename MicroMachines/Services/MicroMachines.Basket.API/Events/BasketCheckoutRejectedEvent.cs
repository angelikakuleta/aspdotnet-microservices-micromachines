using MicroMachines.Basket.API.Entities;
using MicroMachines.EventBus.RabbitMQ;
using System;
using System.Collections.Generic;

namespace MicroMachines.Basket.API.Events
{
    public class BasketCheckoutRejectedEvent : Event
    {
        public Guid UserId { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
