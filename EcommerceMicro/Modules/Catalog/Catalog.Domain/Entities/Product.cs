using BuildingBlocks.SharedKernel;

namespace Catalog.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }
    public Guid BrandId { get; private set; }

    public int AvailableQuantity { get; private set; }
    public int ReservedQuantity { get; private set; }

    private Product() { }

    public Product(string name, decimal price, Guid categoryId, Guid brandId, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (price <= 0)
            throw new ArgumentException("Invalid price");

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        CategoryId = categoryId;
        BrandId = brandId;
        AvailableQuantity = quantity;
        ReservedQuantity = 0;
    }

    public Result ReserveStock(int quantity)
    {
        if (quantity <= 0)
            return Result.Failure("Invalid quantity");

        if (AvailableQuantity < quantity)
            return Result.Failure("Out of stock");

        AvailableQuantity -= quantity;
        ReservedQuantity += quantity;

        return Result.Success();
    }

    public Result CommitStock(int quantity)
    {
        if (quantity <= 0)
            return Result.Failure("Invalid quantity");

        if (ReservedQuantity < quantity)
            return Result.Failure("Not enough reserved stock");

        ReservedQuantity -= quantity;

        return Result.Success();
    }

    public Result ReleaseStock(int quantity)
    {
        if (quantity <= 0)
            return Result.Failure("Invalid quantity");

        if (ReservedQuantity < quantity)
            return Result.Failure("Not enough reserved stock");

        ReservedQuantity -= quantity;
        AvailableQuantity += quantity;

        return Result.Success();
    }
}