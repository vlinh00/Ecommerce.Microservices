using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _context;
    public CategoryRepository(CatalogDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }

    public Task<Category?> GetByIdAsync(Guid id)
   => _context.Categories.FindAsync(id).AsTask();

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
