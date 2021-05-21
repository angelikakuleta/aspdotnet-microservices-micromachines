using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MicroMachines.Shopping.Domain.Entities;
using MicroMachines.MicroMachines.Shopping.Domain.Interfaces;

namespace MicroMachines.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrdersController(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("id:Guid", Name = "GetOrder")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _repository.GetSingle(id);
            if (order == null) return NotFound();

            return Ok(order);
        }
    }
}
