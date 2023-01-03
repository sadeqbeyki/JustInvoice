namespace JI.DomainContracts.Products;

public interface IGetAllProductsQuery
{
    List<ProductDto> GetProducts();
}
