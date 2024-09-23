namespace Domain.ValueObjects.City;
public record CityId
{
    public int Value { get; }
    private CityId(int value) => Value = value;
    public static CityId Of(int value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == 0)
        {
            throw new DomainException("CityId cannot be Zero.");
        }

        return new CityId(value);
    }
}
