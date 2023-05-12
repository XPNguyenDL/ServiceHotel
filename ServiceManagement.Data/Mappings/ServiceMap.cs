using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class ServiceMap : IEntityTypeConfiguration<Service>
{
	public void Configure(EntityTypeBuilder<Service> builder)
	{
		builder.ToTable("Services");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Name)
			.HasMaxLength(128)
			.IsRequired();

		builder.Property(p => p.ShortDescription)
			.HasMaxLength(512);
		
		builder.Property(p => p.Description)
			.HasMaxLength(512);

		builder.Property(p => p.IsDeleted)
			.IsRequired()
			.HasDefaultValue(false);

		builder.Property(p => p.Available)
			.IsRequired()
			.HasDefaultValue(true);

		builder.HasOne(s => s.Category)
			.WithMany(s => s.Services)
			.HasForeignKey(s => s.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}