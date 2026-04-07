using System;
using Ordering.Application.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    public Task AddAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
