using System;
using Ordering.Domain.Entities;

namespace Ordering.Application.Abstractions;

public interface IOrderItemRepository
{
    Task<OrderItem> GetByIdAsync(Guid orderItemId);
    Task AddAsync(OrderItem orderItem);
    Task UpdateAsync(OrderItem orderItem);
    Task SaveChangesAsync();
}
