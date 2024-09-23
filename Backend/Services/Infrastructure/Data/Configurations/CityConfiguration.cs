using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.ValueObjects.City;

namespace Infrastructure.Data.Configurations;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Id).HasConversion(
                cityId => cityId.Value,
                dbId => CityId.Of(dbId));

        builder.ComplexProperty(
           c => c.Title, nameBuilder =>
           {
               nameBuilder.Property(n => n.Value)
                   .HasColumnName(nameof(City.Title))
                   .HasMaxLength(30)
                   .IsUnicode(false);
           });
        //builder.HasIndex(c => c.Title).IsDescending();
    }
}
