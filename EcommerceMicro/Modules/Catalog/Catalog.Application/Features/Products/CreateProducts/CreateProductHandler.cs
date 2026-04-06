using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
namespace Catalog.Application.Features.Products.CreateProducts;
public class CreateProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IBrandRepository _brandRepository;

    public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _brandRepository = brandRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand cmd)
    {
        if (await _categoryRepository.GetByIdAsync(cmd.CategoryId) is null)
            throw new Exception("Category not found");

        if (await _brandRepository.GetByIdAsync(cmd.BrandId) is null)
            throw new Exception("Brand not found");

        var product = new Product(
            cmd.Name,
            cmd.Price,
            cmd.CategoryId,
            cmd.BrandId,
            cmd.Quantity
        );

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return product.Id;
    }
}