using JI.ApplicationContracts.Invoice;
using JI.ApplicationContracts.Products;
using JI.ApplicationContracts.Units;
using JI.ApplicationServices;
using JI.DAL.Common;
using JI.DAL.Persistance;
using JI.Domain.InvoiceAgg;
using JI.Domain.ProductAgg;
using JI.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JI.DAL;

public class ServicesConfigure
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductApplication, ProductApplication>();

        services.AddTransient<IUnitRepository, UnitRepository>();
        services.AddTransient<IUnitApplication, UnitApplication>();

        services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        services.AddTransient<IInvoiceApplication, InvoiceApplication>();

        services.AddDbContext<InvoiceContext>(x => x.UseSqlServer(connectionString));
    }
}