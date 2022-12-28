using JI.Persistence.Config;
using JI.Domain.InvoiceAgg;
using JI.Domain.ItemAgg;
using JI.Domain.ProductAgg;
using JI.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;

namespace JI.Persistence.Common;

public class InvoiceContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
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