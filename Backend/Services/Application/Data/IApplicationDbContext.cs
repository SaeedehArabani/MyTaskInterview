namespace Application.Data;
public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<City> Cities { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
