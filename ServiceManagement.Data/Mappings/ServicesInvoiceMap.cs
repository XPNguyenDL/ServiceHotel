using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class ServicesInvoiceMap : IEntityTypeConfiguration<ServicesInvoice>
{
	public void Configure(EntityTypeBuilder<ServicesInvoice> builder)
	{
		builder.ToTable("ServicesInvoices");

		builder.HasKey(s => new
		{
			s.InvoiceId, s.ServiceId
		});

		builder.Property(s => s.Quantity)
			.IsRequired()
			.HasDefaultValue(1);

		builder.Property(s => s.Price)
			.IsRequired()
			.HasDefaultValue(0);

		builder.HasOne(s => s.Invoice)
			.WithMany(s => s.ServicesInvoices)
			.HasForeignKey(s => s.InvoiceId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(s => s.Service)
			.WithMany(s => s.ServicesInvoices)
			.HasForeignKey(s => s.ServiceId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}