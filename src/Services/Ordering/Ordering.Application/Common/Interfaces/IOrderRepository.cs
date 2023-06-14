﻿using Contracts.Domains.Interfaces;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Interfaces;

public interface IOrderRepository : IRepositoryBaseAsync<Order, long>
{
    Task<IEnumerable<Order>> GetOrdersByUserNameAsync(string userName);
    Task<Order> GetOrderByDocumentNo(string documentNo);
    void CreateOrder(Order order);
    Task<Order> UpdateOrderAsync(Order order);
    void DeleteOrder(Order order);
}
