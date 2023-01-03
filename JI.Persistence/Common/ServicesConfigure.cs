using JI.ApplicationServices.Invoices;
using JI.ApplicationServices.Products.Query;
using JI.ApplicationServices.Units.Query;
using JI.Domain.InvoiceAgg;
using JI.Domain.ProductAgg;
using JI.Domain.UnitAgg;
using JI.DomainContracts.Invoice;
using JI.DomainContracts.Products;
using JI.DomainContracts.Units;
using JI.Persistence.Invoices;
using JI.Persistence.Products;
using JI.Persistence.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JI.Persistence.Common;

public class ServicesConfigure
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IGetAllProductsQuery, GetAllProductsQuery>();

        services.AddTransient<IUnitRepository, UnitRepository>();
        services.AddTransient<IGetAllUnitsQuery, GetAllUnitsQuery>();

        services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        services.AddTransient<IInvoiceApplication, InvoiceApplication>();

        services.AddDbContext<InvoiceContext>(x => x.UseSqlServer(connectionString));
    }
}