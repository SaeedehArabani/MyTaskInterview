namespace Application.Customers.Commands.DeleteCustomer;
public class DeleteCustomerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteCustomerCommand, DeleteCustomerResult>
{
    public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        //Delete Customer entity from command object
        //save to database
        //return result

        var customerId = CustomerId.Of(command.CustomerId);
        var customer = await dbContext.Customers
            .FindAsync([customerId], cancellationToken: cancellationToken);

        if (customer is null)
        {
            throw new CustomerNotFoundException(command.CustomerId);
        }

        dbContext.Customers.Remove(customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteCustomerResult(true);        
    }
}
