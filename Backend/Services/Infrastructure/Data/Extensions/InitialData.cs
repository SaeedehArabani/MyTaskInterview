using Domain.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.City;
using Domain.ValueObjects.Customer;

namespace Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    new List<Customer>
    {
        Customer.Create(CustomerName.Of("Saeedeh"),CustomerAddress.Of("Tehran"),CityId.Of(1),CustomerPhone.Of("09120000000"),CustomerFax.Of("0210000000"),CustomerCoworkers.Of(1)),
        Customer.Create(CustomerName.Of("Ali"),CustomerAddress.Of("Guilan"),CityId.Of(2),CustomerPhone.Of("09120000001"),CustomerFax.Of("0210000004"),CustomerCoworkers.Of(3)),
      
    };

    public static IEnumerable<City> Cities =>
        new List<City>
        {
            City.Create(CityTitle.Of("Tehran")),
            City.Create(CityTitle.Of("Guilan")),
        };

}
