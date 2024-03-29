﻿using JI.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JI.Persistence.Units;
public class UnitConfig : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Unit).HasForeignKey(x => x.UnitId);
    }
}
