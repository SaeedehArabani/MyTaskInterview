using BuildingBlocks.Pagination;
using Application.Customers.Queries.GetCustomersTxt;
using System.Text;

namespace API.Endpoints;

//- Accepts pagination parameters.
//- Constructs a GetCustomersQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetCustomersRequest(PaginationRequest PaginationRequest);
public record GetCustomersTxtResponse(PaginatedResult<CustomerDto> Customers);

public class GetCustomersTxt : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers/getTxt", async (ISender sender) =>
        {
            var result = await sender.Send(new GetCustomersTxtQuery());

            var response = result.Adapt<GetCustomersTxtResult>();

            return Results.File(response.Customers, "application/octet-stream", $"CustomersList {DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt");
        })
        .WithName("GetCustomersTxt")
        .Produces<GetCustomersTxtResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get CustomersTxt")
        .WithDescription("Get CustomersTxt");
    }
}
