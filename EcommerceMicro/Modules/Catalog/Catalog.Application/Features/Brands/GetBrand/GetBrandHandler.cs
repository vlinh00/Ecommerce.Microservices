using System;
using System.Numerics;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Brands.GetBrand;

public class GetBrandHandler
{
    private readonly IBrandRepository _brandRepository;
    public GetBrandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    public  async Task<Brand> Handle(GetBrandQuery query)
    {
        var brand = await _brandRepository.GetByIdAsync(query.Id);
        if (brand is null)
            throw new Exception("Brand not found");
        return brand;

    }
}
