using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class PriceHistoriesMap : IEntityTypeConfiguration<PriceHistory> {
    public void Configure(EntityTypeBuilder<PriceHistory> builder) {
        builder.ToTable("PriceHistories");

        builder.HasKey(x => x.Id);

        builder.Property(s => s.ModifyTime)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(s => s.Note)
            .HasMaxLength(512);

        builder.HasOne(s => s.Service)
            .WithMany(s => s.PriceHistories)
            .HasForeignKey(s => s.ServiceId);

        builder.HasOne(s => s.Price)
            .WithMany(s => s.PriceHistories)
            .HasForeignKey(s => s.PriceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}