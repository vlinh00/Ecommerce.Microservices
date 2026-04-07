using System;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Categories.GetAllCategories;

public class GetAllCategoriesHandler
{
    private readonly ICategoryRepository _categoryRepository;
    public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

    }
    public async Task<List<Category>> Handle(GetAllCategoriesQuery query, CancellationToken ct)
    {
        return await _categoryRepository.GetAllAsync();
    }
}
