namespace Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(int Id) 
    : IQuery<GetCustomerByIdResult>;

public record GetCustomerByIdResult(CustomerDto? Customer);
