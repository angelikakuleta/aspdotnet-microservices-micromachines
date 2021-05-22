using AutoMapper;
using MicroMachines.Shopping.API.Commands;
using MicroMachines.Shopping.API.Dtos;
using MicroMachines.Shopping.API.Queries;
using MicroMachines.Shopping.Domain.Entities;

namespace MicroMachines.Shopping.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Address, AddressDto>()
                .ForMember(x => x.FullName, x => x.MapFrom(x => string.Join(' ', x.FistName, x.LastName)));
            CreateMap<Order, OrderVm>()
                .ForMember(x => x.OrderStatus, x => x.MapFrom(x => x.Status.ToString()));
            CreateMap<CheckoutOrderItemDto, OrderItem>();
            CreateMap<CheckoutOrderCommand, Address>();
            CreateMap<CheckoutOrderCommand, Order>()
                .ForMember(x => x.BuyerId, x => x.MapFrom(x => x.UserId))
                .ForMember(x => x.Address, x => x.MapFrom(x => x));       
        }
    }
}
