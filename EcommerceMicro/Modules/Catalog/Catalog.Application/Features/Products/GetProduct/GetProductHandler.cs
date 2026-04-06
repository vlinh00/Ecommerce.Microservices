using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
namespace Catalog.Application.Features.Products.GetProduct;
public class GetProductHandler
{
    private readonly IProductRepository _productRepository;
    public GetProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(GetProductQuery query)
    {
        var product = await _productRepository.GetByIdAsync(query.Id);
        if (product is null)
            throw new Exception("Product not found");
        return product;
    }
    
}