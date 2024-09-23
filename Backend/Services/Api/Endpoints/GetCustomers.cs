using BuildingBlocks.Pagination;
using Application.Customers.Queries.GetCustomers;

namespace API.Endpoints;

//- Accepts pagination parameters.
//- Constructs a GetCustomersQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetCustomersRequest(PaginationRequest PaginationRequest);
public record GetCustomersResponse(PaginatedResult<CustomersDto> Customers);

public class GetCustomers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetCustomersQuery(request));

            var response = result.Adapt<GetCustomersResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCustomers")
        .Produces<GetCustomersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Customers")
        .WithDescription("Get Customers");
    }
}
