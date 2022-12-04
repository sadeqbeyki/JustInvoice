using Invoice.DAL;
using Invoice.Domain.ProductAgg;

namespace Invoice.Persistance;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(InvoiceContext dbContext) : base(dbContext)
    {
    }
}
