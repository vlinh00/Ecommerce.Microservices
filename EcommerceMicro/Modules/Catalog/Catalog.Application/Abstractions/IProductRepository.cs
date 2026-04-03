using Catalog.Domain.Entities;
namespace Catalog.Application.Abstractions;
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task SaveChangesAsync();
}