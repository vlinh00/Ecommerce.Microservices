using Catalog.Domain.Entities;
namespace Catalog.Application.Abstractions;
public interface IBrandRepository
{
    Task<Brand?> GetByIdAsync(Guid id);
    Task AddAsync(Brand brand);
    Task SaveChangesAsync();
}