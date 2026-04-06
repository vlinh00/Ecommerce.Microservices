using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
namespace Catalog.Application.Features.Categories.CreateCategory;
public class CreateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateCategoryCommand cmd)
    {
        var category = new Category(cmd.Name);

        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        return category.Id;
    }
}