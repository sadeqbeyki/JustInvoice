using JI.ApplicationContracts.Invoice;
using JI.Domain.InvoiceAgg;
using JI.DomainContracts.Common;
using JI.DomainContracts.Products;

namespace JI.Domain.ProductAgg;
public interface IProductRepository : IBaseRepository<long, Product>
{
    List<ProductDto> GetProducts();

    void DelEdit(ProductDto product);
    void AddEdit(ProductDto product);
}
