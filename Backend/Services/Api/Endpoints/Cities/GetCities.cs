using Application.Cities.Queries.GetCities;

namespace API.Endpoints.Cities;

//- Accepts pagination parameters.
//- Constructs a GetCitiesQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

public record GetCitiesResponse(IEnumerable<CityDto> Cities);

public class GetCities : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/cities", async (ISender sender) =>
        {
            var result = await sender.Send(new GetCitiesQuery());

            var response = result.Adapt<GetCitiesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCities")
        .Produces<GetCitiesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Cities")
        .WithDescription("Get Cities");
    }
}
