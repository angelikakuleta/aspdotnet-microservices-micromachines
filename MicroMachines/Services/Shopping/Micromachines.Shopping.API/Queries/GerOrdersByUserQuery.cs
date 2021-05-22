using AutoMapper;
using MediatR;
using MicroMachines.MicroMachines.Shopping.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroMachines.Shopping.API.Queries
{
    public class GerOrdersByUserQuery : IRequest<List<OrderVm>>
    {
        public Guid UserId { get; private set; }

        public GerOrdersByUserQuery(Guid userId)
        {
            UserId = userId;
        }

        class GerOrdersByUserQueryHandler : IRequestHandler<GerOrdersByUserQuery, List<OrderVm>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GerOrdersByUserQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<OrderVm>> Handle(GerOrdersByUserQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetByUser(request.UserId);
                return _mapper.Map<List<OrderVm>>(orders);
            }
        }
    }
}
