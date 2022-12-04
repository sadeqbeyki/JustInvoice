using Invoice.DAL.Config;
using Invoice.Domain.FactorAgg;
using Invoice.Domain.ItemAgg;
using Invoice.Domain.ProductAgg;
using Invoice.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;

namespace Invoice.DAL.Common;

public class InvoiceContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Factor> Factors { get; set; }
    public InvoiceContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ItemConfig).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }

}