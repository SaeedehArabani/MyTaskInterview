using Application.Customers.Commands.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints;

//- Accepts a CreateCustomerRequest object.
//- Maps the request to a CreateCustomerCommand.
//- Uses MediatR to send the command to the corresponding handler.
//- Returns a response with the created Customer's Id.

//public record CreateCustomerRequest(CustomerDto Customer);
public record CreateCustomerResponse(int Id);

public class CreateCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", async (CustomerDto request, ISender sender) =>
        {
            var result = await sender.Send(new CreateCustomerCommand(request));

            var response = result.Adapt<CreateCustomerResponse>();

            return Results.Created($"/customers/{response.Id}", response);
        })
        .WithName("CreateCustomer")
        .Produces<CreateCustomerResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Customer")
        .WithDescription("Create Customer");
    }
}