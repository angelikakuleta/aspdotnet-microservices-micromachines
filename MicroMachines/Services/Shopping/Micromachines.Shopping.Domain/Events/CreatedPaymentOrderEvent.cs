using MicroMachines.EventBus.RabbitMQ;
using System;

namespace MicroMachines.Shopping.Domain.Events
{
    public class CreatedPaymentOrderEvent : Event
    {
        public Guid From { get; private set; }
        public Guid To { get; private set; }
        public decimal Amount { get; private set; }

        public CreatedPaymentOrderEvent(Guid from, Guid to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
