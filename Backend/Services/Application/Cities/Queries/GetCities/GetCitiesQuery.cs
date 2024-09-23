namespace Application.Cities.Queries.GetCities;

public record GetCitiesQuery()
    : IQuery<GetCitiesResult>;

public record GetCitiesResult(IEnumerable<CityDto> Cities);