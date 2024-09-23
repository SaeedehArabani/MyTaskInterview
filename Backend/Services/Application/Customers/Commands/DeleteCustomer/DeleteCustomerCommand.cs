using FluentValidation;

namespace Application.Customers.Commands.DeleteCustomer;

public record DeleteCustomerCommand(int CustomerId)
    : ICommand<DeleteCustomerResult>;

public record DeleteCustomerResult(bool IsSuccess);

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required");
    }
}
