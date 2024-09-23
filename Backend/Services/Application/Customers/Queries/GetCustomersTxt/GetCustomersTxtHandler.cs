namespace Application.Customers.Queries.GetCustomersTxt;
public class GetCustomersTxtHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomersTxtQuery,GetCustomersTxtResult>
{
    public async Task<GetCustomersTxtResult> Handle(GetCustomersTxtQuery query, CancellationToken cancellationToken)
    {
        // get customers txt file using dbContext
        // return result

        var customers = await dbContext.Customers
                .Include(o => o.City)
                .AsNoTracking()
                .OrderBy(o => o.Name.Value)
                .ToListAsync(cancellationToken);                

        return new GetCustomersTxtResult(customers.ToCustomersTxt());
    }    
}
