using MicroMachines.EventBus.Interfaces;
using System;

namespace MicroMachines.EventBus.RabbitMQ
{
    public abstract class Event : IEvent
    {
        public DateTime TimeStamp { get; protected set; }

        public Event()
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}
