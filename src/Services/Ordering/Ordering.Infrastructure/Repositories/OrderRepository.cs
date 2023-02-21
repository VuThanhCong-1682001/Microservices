using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;
using Infrastructure.Common;
using Ordering.Application.Common.Interfaces;
using Contracts.Domains.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order, long, OrderContext>, IOrderRepository
    {
        public OrderRepository(
            OrderContext dbContext, 
            IUnitOfWork<OrderContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await CreateAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName) =>
            await FindByCondition(x => x.UserName.Equals(userName)).ToListAsync();
    }
}
