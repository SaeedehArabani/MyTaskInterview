namespace Domain.ValueObjects.City;
public record CityTitle
{
    private const int MaxLength = 30;
    public string Value { get; }
    private CityTitle(string value) => Value = value;
    public static CityTitle Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);

        return new CityTitle(value);
    }
}
