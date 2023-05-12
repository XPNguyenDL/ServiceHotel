using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class FeedbackMap : IEntityTypeConfiguration<Feedback>
{
	public void Configure(EntityTypeBuilder<Feedback> builder)
	{
		builder.ToTable("Feedback");

		builder.HasKey(x => x.Id);

		builder.Property(s => s.UserName)
			.IsRequired()
			.HasMaxLength(128);

		builder.Property(s => s.Description)
			.HasMaxLength(512)
			.IsRequired();

		builder.Property(s => s.Rating)
			.IsRequired()
			.HasDefaultValue(0);

		builder.Property(s => s.MaxRating)
			.IsRequired()
			.HasDefaultValue(10);

		builder.HasOne(s => s.Service)
			.WithMany(s => s.Feedback)
			.HasForeignKey(s => s.ServiceId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}