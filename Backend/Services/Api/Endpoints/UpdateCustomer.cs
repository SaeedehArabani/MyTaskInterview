using Application.Customers.Commands.UpdateCustomer;

namespace API.Endpoints;

//- Accepts a UpdateCustomerRequest.
//- Maps the request to an UpdateCustomerCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

//public record UpdateCustomerRequest(CustomerDto Customer);
public record UpdateCustomerResponse(bool IsSuccess);

public class UpdateCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/customers", async (CustomerDto request, ISender sender) =>
        {
            var result = await sender.Send(new UpdateCustomerCommand(request));

            var response = result.Adapt<UpdateCustomerResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateCustomer")
        .Produces<UpdateCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Customer")
        .WithDescription("Update Customer");
    }
}
