namespace Application.Customers.Queries.GetCustomerById;
public class GetCustomerByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
{
    public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        // get Customer by Id using dbContext
        // return result

        var customer = await dbContext.Customers
                        .Include(o => o.City)
                        .AsNoTracking()
                        .Where(o => o.Id == CustomerId.Of(query.Id))
                        .FirstOrDefaultAsync(cancellationToken);

        return new GetCustomerByIdResult(customer.ToCustomerDto());
    }
}
