using Application.Customers.Commands.DeleteCustomer;

namespace API.Endpoints;

//- Accepts the customer Id as a parameter.
//- Constructs a DeleteCustomerCommand.
//- Sends the command using MediatR.
//- Returns a success or not found response.

//public record DeleteCustomerRequest(int Id);
public record DeleteCustomerResponse(bool IsSuccess);

public class DeleteCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/customers/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteCustomerCommand(id));

            var response = result.Adapt<DeleteCustomerResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteCustomer")
        .Produces<DeleteCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Customer")
        .WithDescription("Delete Customer");
    }
}
