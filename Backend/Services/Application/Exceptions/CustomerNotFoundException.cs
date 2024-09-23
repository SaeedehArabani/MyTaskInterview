using BuildingBlocks.Exceptions;

namespace Application.Exceptions;
public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(int id) : base("Customer", id)
    {
    }
}
