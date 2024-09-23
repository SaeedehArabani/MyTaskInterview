namespace Domain.ValueObjects.Customer;
public record CustomerAddress
{
    private const int MaxLength = 200;
    public string? Value { get; }
    private CustomerAddress(string? value) => Value = value;
    public static CustomerAddress Of(string? value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value != default ? value.Length : 0, MaxLength);

        return new CustomerAddress(value);
    }
}
