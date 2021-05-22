using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MicroMachines.Shopping.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using MicroMachines.MicroMachines.Shopping.Domain.Interfaces;

namespace MicroMachines.Shopping.API.Commands
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            // do other staff

            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.Add(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            return newOrder.Id;
        }
    }
}
