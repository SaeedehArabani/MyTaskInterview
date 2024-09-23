namespace Domain.ValueObjects.Customer;
public record CustomerPhone
{
    private const int MaxLength = 20;
    public string? Value { get; }
    private CustomerPhone(string? value) => Value = value;
    public static CustomerPhone Of(string? value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value != default ? value.Length : 0, MaxLength);

        return new CustomerPhone(value);
    }
}
