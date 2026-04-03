using Catalog.Application.Abstractions;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _context;
    public ProductRepository(CatalogDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}