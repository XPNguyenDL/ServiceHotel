using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class CarMap : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.ToTable("Cars");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Type)
			.HasMaxLength(128)
			.IsRequired();

		builder.Property(p => p.Brand)
			.HasMaxLength(512)
			.IsRequired();

		builder.Property(p => p.DayRent)
			.IsRequired()
			.HasDefaultValue(1);

		builder.Property(p => p.Status)
			.IsRequired();

		builder.HasOne(s => s.Service)
			.WithOne(s => s.Car)
			.HasForeignKey<Service>(s => s.Id);
	}
}