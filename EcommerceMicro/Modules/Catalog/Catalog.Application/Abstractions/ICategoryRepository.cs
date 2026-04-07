using Catalog.Domain.Entities;
namespace Catalog.Application.Abstractions;
public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<List<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task SaveChangesAsync();
}