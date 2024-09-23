namespace Application.Cities.Queries.GetCities;
public class GetCitiesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCitiesQuery, GetCitiesResult>
{
    public async Task<GetCitiesResult> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
    {
        // get cities 
        // return result

        var cities = await dbContext.Cities
                       .OrderBy(o => o.Id)
                       .ToListAsync(cancellationToken);
        var citesDto = cities.ToCityDtoList();

        return new GetCitiesResult(citesDto);
    }
}
