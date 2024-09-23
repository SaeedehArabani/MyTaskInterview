using FluentValidation;

namespace Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(CustomerDto Customer)
    : ICommand<CreateCustomerResult>;

public record CreateCustomerResult(int Id);

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Customer.Name).NotEmpty().WithMessage("Name is required").MaximumLength(30).WithMessage("Maximum Length is 30 Characters");
        RuleFor(x => x.Customer.Address).MaximumLength(200).WithMessage("Maximum Length is 200 Characters");
        RuleFor(x => x.Customer.City).NotEmpty().WithMessage("City should not be empty");
        RuleFor(x => x.Customer.Phone).MaximumLength(20).WithMessage("Maximum Length is 20 Characters");
        RuleFor(x => x.Customer.Fax).MaximumLength(20).WithMessage("Maximum Length is 20 Characters");
    }
}