using System;

namespace Ordering.Domain.Entities;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
