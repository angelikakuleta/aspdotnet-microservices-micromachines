using System.Threading.Tasks;

namespace MicroMachines.EventBus.Interfaces
{
    public interface IEventHandler<T> where T: IEvent
    {
        public Task HandleAsync(T @event);
    }
}
