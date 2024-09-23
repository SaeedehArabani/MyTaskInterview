namespace Domain.ValueObjects;
public record CustomerCoworkers
{
    public int? Value { get; }
    private CustomerCoworkers(int? value) => Value = value;
    public static CustomerCoworkers Of(int? value)
    {
        ArgumentNullException.ThrowIfNull(value);
       
        return new CustomerCoworkers(value);
    }
}
