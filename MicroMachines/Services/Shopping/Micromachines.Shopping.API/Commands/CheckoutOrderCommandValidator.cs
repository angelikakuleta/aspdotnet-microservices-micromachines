using FluentValidation;

namespace MicroMachines.Shopping.API.Commands
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AccountId).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.OrderItems).NotEmpty();
            RuleForEach(x => x.OrderItems).SetValidator(new CheckoutOrderItemDtoValidator());
        }
    }

    public class CheckoutOrderItemDtoValidator : AbstractValidator<CheckoutOrderItemDto>
    {
        public CheckoutOrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
