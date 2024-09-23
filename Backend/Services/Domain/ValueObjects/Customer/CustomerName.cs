namespace Domain.ValueObjects.Customer;
public record CustomerName
{
    private const int MaxLength = 30;
    public string Value { get; }
    private CustomerName(string value) => Value = value;
    public static CustomerName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, MaxLength);

        return new CustomerName(value);
    }
}
