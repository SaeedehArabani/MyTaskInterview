namespace Application.Customers.Queries.GetCustomersTxt;

public record GetCustomersTxtQuery()
    : IQuery<GetCustomersTxtResult>;

public record GetCustomersTxtResult(byte[] Customers);