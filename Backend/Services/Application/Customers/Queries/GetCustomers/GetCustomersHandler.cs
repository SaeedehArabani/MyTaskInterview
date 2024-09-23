using BuildingBlocks.Pagination;

namespace Application.Customers.Queries.GetCustomers;
public class GetCustomersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomersQuery, GetCustomersResult>
{
    public async Task<GetCustomersResult> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
    {
        // get customers with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Customers.LongCountAsync(cancellationToken);

        var customers = await dbContext.Customers
                       .Include(o => o.City)
                       .OrderBy(o => o.Name.Value)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);
        var customersDto = customers.ToCustomersDtoList();

        return new GetCustomersResult(
            new PaginatedResult<CustomersDto>(
                pageIndex,
                pageSize,
                totalCount,
               customersDto));
    }
}
