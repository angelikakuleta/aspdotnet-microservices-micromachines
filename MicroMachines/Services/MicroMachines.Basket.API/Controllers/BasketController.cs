using AutoMapper;
using MicroMachines.Basket.API.Clients;
using MicroMachines.Basket.API.Commands;
using MicroMachines.Basket.API.Entities;
using MicroMachines.Basket.API.Events;
using MicroMachines.Basket.API.Repositories;
using MicroMachines.EventBus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MicroServices.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _repository;
        private readonly ITransferClient _transferClient;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public BasketController(ILogger<BasketController> logger, IBasketRepository repository, ITransferClient transferClient, IMapper mapper, IEventBus eventBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(repository));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _transferClient = transferClient ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("userId:Guid", Name = "GetBasket")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCart))]
        public async Task<ActionResult<ShoppingCart>> GetBasket(Guid userId)
        {
            var basket = await _repository.GetSingle(userId);
            return Ok(basket ?? new ShoppingCart(userId));
        }

        [HttpPost("userId:Guid/checkout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Checkout(Guid userId, [FromBody] BasketCheckoutCommand command)
        {
            var basket = await _repository.GetSingle(userId);
            if (basket == null || basket.Items.Count == 0) return NotFound();

            var account = await _transferClient.GetAccount(command.AccountFromId);
            if (account == null || account.UserId != userId) BadRequest();

            string response = string.Empty;
            if (account.Balance >= basket.TotalPrice)
            {
                var message = _mapper.Map<BasketCheckoutAcceptedEvent>(command);
                message.Items = basket.Items;
                message.UserId = userId;
                _eventBus.Publish(message);
                _logger.LogInformation("Event {event} has been published for user with id: {id}.", typeof(BasketCheckoutAcceptedEvent).Name, userId);
                response = "The order has been accepted and is waiting to be processed.";
            }
            else
            {
                var message = new BasketCheckoutRejectedEvent()
                {
                    UserId = userId,
                    Items = basket.Items
                };
                _eventBus.Publish(message);
                _logger.LogInformation("Event {event} has been published for user with id: {id}. ", typeof(BasketCheckoutRejectedEvent).Name, userId);
                response = "Account balance too low. The products have been moved to the wishlist.";
            }
            
            return Accepted(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCart))]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart basket)
        {
            return Ok(await _repository.Edit(basket));
        }

        [HttpDelete("userId:Guid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBasket(Guid userId)
        {
            await _repository.Delete(userId);
            return Ok();
        }
    }
}
