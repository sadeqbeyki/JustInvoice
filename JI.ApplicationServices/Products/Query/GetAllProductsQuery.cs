using JI.Domain.ProductAgg;
using JI.DomainContracts.Products;

namespace JI.ApplicationServices.Products.Query;

public class GetAllProductsQuery : IGetAllProductsQuery
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQuery(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductDto> GetProducts()
    {
        return _productRepository.GetProducts();
    }
}