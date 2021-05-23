using MicroMachines.EventBus.Interfaces;
using MicroMachines.Shopping.Domain.Events;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MicroMachines.Shopping.API.EventHandlers
{
    public class BasketCheckoutAcceptedEventHandler : IEventHandler<BasketCheckoutAcceptedEvent>
    {
        private readonly ILogger<BasketCheckoutAcceptedEventHandler> _logger;

        public BasketCheckoutAcceptedEventHandler(ILogger<BasketCheckoutAcceptedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(BasketCheckoutAcceptedEvent @event)
        {
            _logger.LogInformation($"Event BasketCheckoutEvent consumed successfully.");
            return Task.CompletedTask;
        }
    }
}
