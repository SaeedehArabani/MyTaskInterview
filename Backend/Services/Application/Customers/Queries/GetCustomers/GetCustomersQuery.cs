using BuildingBlocks.Pagination;

namespace Application.Customers.Queries.GetCustomers;

public record GetCustomersQuery(PaginationRequest PaginationRequest) 
    : IQuery<GetCustomersResult>;

public record GetCustomersResult(PaginatedResult<CustomersDto> Customers);