public record CreateProductCommand(
    string Name,
    decimal Price,
    Guid CategoryId,
    Guid BrandId,
    int Quantity
);