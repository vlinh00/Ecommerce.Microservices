using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
namespace Catalog.Application.Features.Brands.CreateBrand;  
public class CreateBrandHandler
{
    private readonly IBrandRepository _brandRepository;

    public CreateBrandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<Guid> Handle(CreateBrandCommand cmd)
    {
        var brand = new Brand(cmd.Name);

        await _brandRepository.AddAsync(brand);
        await _brandRepository.SaveChangesAsync();

        return brand.Id;
    }
}