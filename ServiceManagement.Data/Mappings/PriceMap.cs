using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class PriceMap : IEntityTypeConfiguration<Price>
{
	public void Configure(EntityTypeBuilder<Price> builder)
	{
		builder.ToTable("Prices");

		builder.HasKey(s => s.Id);

		builder.Property(s => s.ServicePrice)
			.IsRequired()
			.HasDefaultValue(0);

		builder.Property(s => s.Discount)
			.HasDefaultValue(0);
		
	}
}