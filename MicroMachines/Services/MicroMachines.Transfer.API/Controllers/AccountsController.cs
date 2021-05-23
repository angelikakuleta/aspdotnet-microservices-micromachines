using MicroMachines.Transfer.API.Entities;
using MicroMachines.Transfer.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroMachines.Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountsController(IAccountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Account>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Account>>> GetByUser([FromQuery] Guid? userId)
        {
            if (userId == null) return BadRequest();

            var accounts = await _repository.GetByUser((Guid)userId);
            return Ok(accounts);
        }

        [HttpGet("{id:Guid}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Account))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Account>> GetAccount(Guid id)
        {
            var account = await _repository.GetSingle(id);
            if (account == null) return NotFound();

            return Ok(account);
        }
    }
}
