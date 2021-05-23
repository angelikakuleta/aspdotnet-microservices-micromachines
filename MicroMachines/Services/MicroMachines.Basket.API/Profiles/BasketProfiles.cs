using AutoMapper;
using MicroMachines.Basket.API.Commands;
using MicroMachines.Basket.API.Events;

namespace MicroMachines.Basket.API.Profiles
{
    public class BasketProfiles : Profile
    {
        public BasketProfiles()
        {
            CreateMap<BasketCheckoutCommand, BasketCheckoutAcceptedEvent>();
        }
    }
}
