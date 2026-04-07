using System;
using Ordering.Domain.Entities;

namespace Ordering.Application.Abstractions;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid orderId);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task SaveChangesAsync();
}
