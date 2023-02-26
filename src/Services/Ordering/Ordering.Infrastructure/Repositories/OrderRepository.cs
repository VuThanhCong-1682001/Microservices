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

        public void CreateOrder(Order order) => Create(order);

        public async Task<IEnumerable<Order>> GetOrdersByUserNameAsync(string userName) =>
            await FindByCondition(x => x.UserName.Equals(userName)).ToListAsync();

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await UpdateAsync(order);
            return order;
        }

        public void DeleteOrder(Order order) => Delete(order);
    }
}
