namespace Application.Extensions;
public static class CityExtensions
{
    public static IEnumerable<CityDto> ToCityDtoList(this IEnumerable<City> cities)
    {
        return cities.Select(customer => new CityDto(
            Id: customer.Id.Value,
            Title: customer.Title.Value
            ));
    }
}
