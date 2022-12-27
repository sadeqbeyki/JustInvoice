using JI.ApplicationContracts.Products;
using JI.DAL.Common;
using JI.Domain.ProductAgg;

namespace JI.DAL.Persistance;

public class ProductRepository : BaseRepository<long, Product>, IProductRepository
{
    private readonly InvoiceContext _invoiceContext;

    public ProductRepository(InvoiceContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public List<ProductViewModel> GetProducts()
    {
        return _invoiceContext.Products.Select(c => new ProductViewModel
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList();
    }
}
