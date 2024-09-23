namespace Domain.ValueObjects.Customer;
public record CustomerFax
{
    private const int MaxLength = 20;
    public string? Value { get; }
    private CustomerFax(string? value) => Value = value;
    public static CustomerFax Of(string? value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value != default ? value.Length : 0, MaxLength);

        return new CustomerFax(value);
    }
}
