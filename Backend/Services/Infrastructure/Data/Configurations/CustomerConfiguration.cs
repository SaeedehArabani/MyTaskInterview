using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;
using Domain.ValueObjects;

namespace Infrastructure.Data.Configurations;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.City)
           .WithMany(ci => ci.Customers)
           .HasForeignKey(c => c.CityId)
           .IsRequired();

        builder.Property(c => c.Id).HasConversion(
                customerId => customerId.Value,
                dbId => CustomerId.Of(dbId));

        builder.ComplexProperty(
           c => c.Name, nameBuilder =>
           {
               nameBuilder.Property(n => n.Value)
                   .HasColumnName(nameof(Customer.Name))
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired();
           });

        builder.ComplexProperty(
        c => c.Address, nameBuilder =>
        {
            nameBuilder.Property(a => a.Value)
                .HasColumnName(nameof(Customer.Address))
                .HasMaxLength(200)
                .IsUnicode(false);

        });

        // builder.ComplexProperty(
        // c => c.CityId, nameBuilder =>
        // {
        //     nameBuilder.Property(a => a.Value)
        //         .HasColumnName(nameof(Customer.CityId))
        //         .IsRequired();
        // });

        builder.ComplexProperty(
       c => c.Phone, nameBuilder =>
       {
           nameBuilder.Property(a => a.Value)
               .HasColumnName(nameof(Customer.Phone))
               .HasMaxLength(20)
               .IsUnicode(false);

       });

        builder.ComplexProperty(
       c => c.Fax, nameBuilder =>
       {
           nameBuilder.Property(a => a.Value)
               .HasColumnName(nameof(Customer.Fax))
               .HasMaxLength(20)
               .IsUnicode(false);

       });

        builder.ComplexProperty(
       c => c.Coworkers, nameBuilder =>
       {
           nameBuilder.Property(a => a.Value)
               .HasColumnName(nameof(Customer.Coworkers));
       });



        //builder.HasIndex(c => c.Name).IsDescending();
    }
}
