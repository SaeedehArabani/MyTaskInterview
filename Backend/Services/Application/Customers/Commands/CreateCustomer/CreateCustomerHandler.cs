using Domain.ValueObjects.City;
using Domain.ValueObjects.Customer;

namespace Application.Customers.Commands.CreateCustomer;
public class CreateCustomerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        //create Customer entity from command object
        //save to database
        //return result 

        var customer = CreateNewCustomer(command.Customer);

        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCustomerResult(customer.Id.Value);
    }

    private Customer CreateNewCustomer(CustomerDto customerDto)
    {

        var newCustomer = Customer.Create(
                name: CustomerName.Of(customerDto.Name),
                address: CustomerAddress.Of(customerDto.Address),
                cityId: CityId.Of(customerDto.City),
                phone: CustomerPhone.Of(customerDto.Phone),
                fax: CustomerFax.Of(customerDto.Fax),
                coworkers: CustomerCoworkers.Of(customerDto.Coworkers)
               );

        return newCustomer;
    }
}
