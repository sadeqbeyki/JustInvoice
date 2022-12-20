using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.DAL.Config;

public class InvoiceConfig : IEntityTypeConfiguration<Domain.InvoiceAgg.Invoice>
{
    public void Configure(EntityTypeBuilder<Domain.InvoiceAgg.Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.Property(x => x.Name);
        builder.Property(x => x.Total);
        builder.Property(x => x.Description).IsRequired(false);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Invoice).HasForeignKey(x => x.InvoiceId);
    }
}
