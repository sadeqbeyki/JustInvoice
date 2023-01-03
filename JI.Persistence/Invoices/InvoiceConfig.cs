using JI.Domain.InvoiceAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JI.Persistence.Invoices;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.Property(x => x.Name);
        builder.Property(x => x.Total);
        builder.Property(x => x.Photo).IsRequired(false);
        builder.Property(x => x.Description).IsRequired(false);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Invoice).HasForeignKey(x => x.InvoiceId);
    }
}
