namespace MicroMachines.EventBus.Interfaces
{
    public interface IEventBus
    {
        void Publish(IEvent @event);
        void Subsribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>;           
    }
}
