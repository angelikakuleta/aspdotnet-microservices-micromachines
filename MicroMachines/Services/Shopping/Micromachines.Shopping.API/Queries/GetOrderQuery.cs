using AutoMapper;
using MediatR;
using MicroMachines.MicroMachines.Shopping.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroMachines.Shopping.API.Queries
{
    public class GetOrderQuery : IRequest<OrderVm>
    {
        public Guid OrderId { get; private set; }

        public GetOrderQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderVm>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<OrderVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetSingle(request.OrderId);
                return order == null ? null : _mapper.Map<OrderVm>(order);
            }
        }
    }
}
