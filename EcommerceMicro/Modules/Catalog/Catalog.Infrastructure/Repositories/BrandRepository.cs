using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly CatalogDbContext _context;
    public BrandRepository(CatalogDbContext context) {
        _context = context;
    }  
    public async Task AddAsync(Brand brand)
    => await _context.Brands.AddAsync(brand);

    public Task<Brand?> GetByIdAsync(Guid id)
   => _context.Brands.FindAsync(id).AsTask();

    public Task SaveChangesAsync()
    => _context.SaveChangesAsync();
}
