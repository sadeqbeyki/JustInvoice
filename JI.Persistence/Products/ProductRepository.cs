using JI.Domain.ProductAgg;
using JI.DomainContracts.Products;
using JI.Persistence.Common;

namespace JI.Persistence.Products;

public class ProductRepository : BaseRepository<long, Product>, IProductRepository
{
    private readonly InvoiceDbContext _invoiceContext;

    public ProductRepository(InvoiceDbContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public void AddEdit(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public void DelEdit(ProductDto product)
    {
        throw new NotImplementedException();
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
