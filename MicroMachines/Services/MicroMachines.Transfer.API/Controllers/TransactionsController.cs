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
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionsController(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Account>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Account>>> GetByAccount([FromQuery] Guid? accountId)
        {
            if (accountId == null) return BadRequest();

            var transactions = await _transactionRepository.GetByAccount((Guid)accountId);
            return Ok(transactions);
        }

        [HttpGet("{id:Guid}", Name = "GetTranscation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Account))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Account>> GetTranscation(Guid id)
        {
            var transaction = await _transactionRepository.GetSingle(id);
            if (transaction == null) return NotFound();

            return Ok(transaction);
        }
    }
}
