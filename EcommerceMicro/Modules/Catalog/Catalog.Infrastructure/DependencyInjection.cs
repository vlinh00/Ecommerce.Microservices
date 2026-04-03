using Catalog.Application.Abstractions;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalog(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<CatalogDbContext>(opt =>
            opt.UseSqlServer(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        //services.AddScoped<ICategoryRepository, CategoryRepository>();
        //services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }
}