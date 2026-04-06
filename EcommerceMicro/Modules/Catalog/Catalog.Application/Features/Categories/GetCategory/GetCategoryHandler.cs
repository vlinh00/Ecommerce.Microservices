using System;
using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Categories.GetCategory;

public class GetCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Category> Handle(GetCategoryQuery query)
    {
        var category = await _categoryRepository.GetByIdAsync(query.Id);
        if (category is null)
            throw new Exception("Category not found");
        return category;

    }
}
