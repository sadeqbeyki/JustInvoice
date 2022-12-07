﻿using Invoice.ApplicationContracts.Products;
using Invoice.Domain.ProductAgg;

namespace Invoice.ApplicationServices;
public class ProductApplication : IProductApplication
{
    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductViewModel> GetProducts()
    {
        return _productRepository.GetProducts();
    }
}