using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class RoomMap : IEntityTypeConfiguration<Room>
{
	public void Configure(EntityTypeBuilder<Room> builder)
	{
		builder.ToTable("Rooms");

		builder.HasKey(x => x.Id);
	}
}