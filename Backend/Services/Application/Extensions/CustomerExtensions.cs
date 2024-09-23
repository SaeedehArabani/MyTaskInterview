namespace Application.Extensions;
public static class CustomerExtensions
{
    public static IEnumerable<CustomersDto> ToCustomersDtoList(this IEnumerable<Customer> customers)
    {
        return customers.Select(customer => new CustomersDto(
            Id: customer.Id.Value,
            Name: customer.Name.Value,
            Address: customer.Address.Value,
            City: customer.City.Title.Value,
            Phone: customer.Phone.Value,
            Fax: customer.Fax.Value,
            Coworkers: customer.Coworkers.Value
            ));
    }

    public static CustomerDto? ToCustomerDto(this Customer? customer)
    {
        if (customer == default)
        {
            return default;
        }

        return new CustomerDto(
                    Id: customer.Id.Value,
                    Name: customer.Name.Value,
                    Address: customer.Address.Value,
                    City: customer.City.Id.Value,
                    Phone: customer.Phone.Value,
                    Fax: customer.Fax.Value,
                    Coworkers: customer.Coworkers.Value
                    );
    }

    public static byte[] ToCustomersTxt(this IEnumerable<Customer> customers)
    {
        byte[] bytes = [];
        if (customers.Any())
        {
            using (var ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))
                {
                    foreach (var customer in customers)
                    {
                        tw.WriteLine(ToStringFormat(
                            customer.Id.Value,
                            customer.Name.Value,
                            customer.Address.Value,
                            customer.City.Title.Value,
                            customer.Phone.Value,
                            customer.Fax.Value,
                            customer.Coworkers.Value
                        ));
                    }
                    tw.Flush();
                    ms.Position = 0;
                    bytes = ms.ToArray();
                }

            }
        }

        return bytes;
    }

    private static string ToStringFormat(int id, string name, string? address, string city, string? phone, string? fax, int? coworkers)
    {
        return String.Format("{0,-5} {1,-30} {2,-30} {3,-20} {4,-20} {5,-10} {6,-200}",
              id, name, city, phone, fax, address, coworkers);
    }



}
