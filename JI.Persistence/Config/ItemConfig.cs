using JI.Domain.ItemAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JI.Persistence.Config;

public class ItemConfig : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price);
        builder.Property(x => x.Count);
        builder.Property(x => x.Sum);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Items).HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Unit)
            .WithMany(x => x.Items).HasForeignKey(x => x.UnitId);

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Items).HasForeignKey(x => x.InvoiceId);
    }
}
