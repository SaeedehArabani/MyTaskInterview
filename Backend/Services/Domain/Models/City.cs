namespace Domain.Models;
public class City : Entity<CityId>
{
    public CityTitle Title { get; private set; } = default!;
    public ICollection<Customer> Customers { get; } = [];

    public static City Create(CityTitle title)
    {
        var city = new City
        {
            Title = title,
        };
        return city;
    }

    public void Update(CityTitle title)
    {
        Title = title;
    }
}
