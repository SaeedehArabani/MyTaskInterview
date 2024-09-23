

namespace Domain.Models;
public class Customer : Entity<CustomerId>
{
    public CustomerName Name { get; private set; } = default!;
    public CustomerAddress Address { get; private set; } = default!;
    public CityId CityId { get; private set; } = default!;
    public City City { get; private set; } = default!;
    public CustomerPhone Phone { get; private set; } = default!;
    public CustomerFax Fax { get; private set; } = default!;
    public CustomerCoworkers Coworkers { get; private set; } = default!;

    public static Customer Create(CustomerName name, CustomerAddress address, CityId cityId, CustomerPhone phone, CustomerFax fax, CustomerCoworkers coworkers)
    {

        var customer = new Customer
        {
            Name = name,
            Address = address,
            CityId = cityId,
            Phone = phone,
            Fax = fax,
            Coworkers = coworkers
        };
        return customer;
    }

    public void Update(CustomerName name, CustomerAddress address, CityId cityId, CustomerPhone phone, CustomerFax fax, CustomerCoworkers coworkers)
    {
        Name = name;
        Address = address;
        CityId = cityId;
        Phone = phone;
        Fax = fax;
        Coworkers = coworkers;
    }
}
