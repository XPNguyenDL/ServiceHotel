using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class InvoiceMap : IEntityTypeConfiguration<Invoice>
{
	public void Configure(EntityTypeBuilder<Invoice> builder)
	{
		builder.ToTable("Invoices");

		builder.HasKey(x => x.Id);

		builder.Property(s => s.PaymentDate)
			.IsRequired()
			.HasColumnType("datetime");

		builder.Property(s => s.Note)
			.HasMaxLength(512);

		builder.Property(s => s.Total)
			.IsRequired()
			.HasDefaultValue(0);

		builder.Property(s => s.Paid)
			.IsRequired()
			.HasDefaultValue(false);

		builder.HasOne(s => s.Room)
			.WithMany(s => s.Invoices)
			.HasForeignKey(s => s.RoomId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}