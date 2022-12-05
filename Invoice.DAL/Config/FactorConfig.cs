using Invoice.Domain.FactorAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.DAL.Config;

public class FctorConfig : IEntityTypeConfiguration<Factor>
{
    public void Configure(EntityTypeBuilder<Factor> builder)
    {
        builder.ToTable("Factors");

        builder.Property(x => x.Name);
        builder.Property(x => x.Total);
        builder.Property(x => x.Description).IsRequired(false);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.FactorName).HasForeignKey(x => x.FactorId);
    }
}
