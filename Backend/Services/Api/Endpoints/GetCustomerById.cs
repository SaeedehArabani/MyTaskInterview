using Application.Customers.Queries.GetCustomerById;

namespace Ordering.API.Endpoints;

//- Accepts a customer Id.
//- Uses a GetCustomerByIdQuery to fetch Customer.
//- Return customer.

//public record GetCustomerByIdRequest(int id);
public record GetCustomerByIdResponse(CustomerDto Customer);

public class GetCustomerById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new GetCustomerByIdQuery(id));

            var response = result.Adapt<GetCustomerByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCustomerById")
        .Produces<GetCustomerByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Customer By Id")
        .WithDescription("Get Customer By Id");
    }
}
