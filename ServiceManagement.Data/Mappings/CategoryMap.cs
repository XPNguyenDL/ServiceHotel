﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServiceManagement.Core.Entities;

namespace ServiceManagement.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("Categories");

		builder.HasKey(p => p.Id);

		builder.Property(p => p.Name)
			.HasMaxLength(128)
			.IsRequired();

		builder.Property(p => p.Description)
			.HasMaxLength(512);

        builder.Property(p => p.IsDeleted)
			.IsRequired()
			.HasDefaultValue(false);

        builder.Property(p => p.Available)
			.IsRequired()
			.HasDefaultValue(true);
    }
}