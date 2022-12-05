using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.ApplicationContracts.Products;
using Invoice.ApplicationContracts.Units;
using Invoice.ApplicationServices;
using Invoice.DAL.Common;
using Invoice.DAL.Persistance;
using Invoice.Domain.FactorAgg;
using Invoice.Domain.ItemAgg;
using Invoice.Domain.ProductAgg;
using Invoice.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice.DAL;

public class ServicesConfigure
{
    public static void Configure(IServiceCollection services, string connectionString)
    {

        services.AddTransient<IItemRepository, ItemRepository>();
        services.AddTransient<IItemApplication, ItemApplication>();

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductApplication, ProductApplication>();

        services.AddTransient<IUnitRepository, UnitRepository>();
        services.AddTransient<IUnitApplication, UnitApplication>();

        services.AddTransient<IFactorRepository, FactorRepository>();
        services.AddTransient<IFactorApplication, FactorApplication>();

        services.AddDbContext<InvoiceContext>(x => x.UseSqlServer(connectionString));
    }
}