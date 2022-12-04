using Invoice.ApplicationContracts.Products;

namespace Invoice.Domain.ProductAgg;
public interface IProductRepository : IBaseRepository<long, Product>
{
    List<ProductViewModel> GetProducts();
}
