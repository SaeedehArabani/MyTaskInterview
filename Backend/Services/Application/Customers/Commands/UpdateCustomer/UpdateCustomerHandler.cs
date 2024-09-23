using Domain.ValueObjects.City;
using Domain.ValueObjects.Customer;

namespace Application.Customers.Commands.UpdateCustomer;
public class UpdateCustomerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateCustomerCommand, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        //Update Customer entity from command object
        //save to database
        //return result

        var customerId = CustomerId.Of(command.Customer.Id);
        var customer = await dbContext.Customers
            .FindAsync([customerId], cancellationToken: cancellationToken);

        if (customer is null)
        {
            throw new CustomerNotFoundException(command.Customer.Id);
        }

        UpdateCustomerWithNewValues(customer, command.Customer);

        dbContext.Customers.Update(customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerResult(true);
    }

    public void UpdateCustomerWithNewValues(Customer customer, CustomerDto customerDto)
    {
        customer.Update(
                name: CustomerName.Of(customerDto.Name),
                address: CustomerAddress.Of(customerDto.Address),
                cityId: CityId.Of(customerDto.City),
                phone: CustomerPhone.Of(customerDto.Phone),
                fax: CustomerFax.Of(customerDto.Fax),
                coworkers: CustomerCoworkers.Of(customerDto.Coworkers)
            );
    }
}
