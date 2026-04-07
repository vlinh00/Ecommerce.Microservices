using System;

namespace Ordering.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items;

    public decimal TotalPrice { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Order Create(Guid customerId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Status = OrderStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }
    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new Exception("Invalid state");

        Status = OrderStatus.Confirmed;
    }
    public void Cancel()
{
    if (Status == OrderStatus.Confirmed)
        throw new Exception("Cannot cancel confirmed order");

    Status = OrderStatus.Cancelled;
}
    public void Complete()
    {
        if (Status != OrderStatus.Confirmed)
            throw new Exception("Only confirmed orders can be completed");

        Status = OrderStatus.Completed;
    }
    public void AddItem(Guid productId, int quantity, decimal price)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        _items.Add(new OrderItem(productId, quantity, price));
        RecalculateTotal();
    }
    private void RecalculateTotal()
{
    TotalPrice = _items.Sum(x => x.Price * x.Quantity);
}
}
