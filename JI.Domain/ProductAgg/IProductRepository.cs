using JI.ApplicationContracts.Products;

namespace JI.Domain.ProductAgg;
public interface IProductRepository : IBaseRepository<long, Product>
{
    List<ProductViewModel> GetProducts();
}
