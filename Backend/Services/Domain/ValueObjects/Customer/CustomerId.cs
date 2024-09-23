namespace Domain.ValueObjects;
public record CustomerId
{
    public int Value { get; }
    private CustomerId(int value) => Value = value;
    public static CustomerId Of(int value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == 0)
        {
            throw new DomainException("CustomerId cannot be Zero.");
        }

        return new CustomerId(value);
    }
}
