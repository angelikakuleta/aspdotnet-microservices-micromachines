using MediatR;
using MicroMachines.EventBus.Interfaces;
using MicroMachines.Shopping.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.API.Commands
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new CreatedPaymentOrderEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
