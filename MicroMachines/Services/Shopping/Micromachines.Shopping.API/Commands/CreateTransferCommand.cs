using MediatR;
using System;

namespace Shopping.API.Commands
{
    public class CreateTransferCommand : IRequest<bool>
    {
        public Guid From { get; private set; }
        public Guid To { get; private set; }
        public decimal Amount { get; private set; }

        public CreateTransferCommand(Guid from, Guid to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
