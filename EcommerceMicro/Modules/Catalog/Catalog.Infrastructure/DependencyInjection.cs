using Catalog.Application.Abstractions;
using Catalog.Application.Features.Brands.CreateBrand;
using Catalog.Application.Features.Brands.GetBrand;
using Catalog.Application.Features.Categories.CreateCategory;
using Catalog.Application.Features.Categories.GetAllCategories;
using Catalog.Application.Features.Categories.GetCategory;
using Catalog.Application.Features.Products.CreateProducts;
using Catalog.Application.Features.Products.GetProduct;
using Catalog.Infrastructure.Persistence;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalog(
        this IServiceCollection services,
        string connectionString)
    {
        // DbContext
        services.AddDbContext<CatalogDbContext>(opt =>
            opt.UseSqlServer(connectionString));

        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();

        // Handlers (Use cases)
        services.AddScoped<CreateCategoryHandler>();
        services.AddScoped<GetCategoryHandler>();
        services.AddScoped<CreateBrandHandler>();
        services.AddScoped<GetBrandHandler>();
        services.AddScoped<CreateProductHandler>();
        services.AddScoped<GetProductHandler>();
        services.AddScoped<GetAllCategoriesHandler>();

        return services;
    }
}