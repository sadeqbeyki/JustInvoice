using JI.Domain.ProductAgg;
using JI.DomainContracts.Products;
using JI.Persistence.Common;

namespace JI.Persistence.Products;

public class ProductRepository : BaseRepository<long, Product>, IProductRepository
{
    private readonly InvoiceContext _invoiceContext;

    public ProductRepository(InvoiceContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public List<ProductDto> GetProducts()
    {
        return _invoiceContext.Products.Select(c => new ProductDto
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList();
    }
}
