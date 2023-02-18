using Contracts.Domains.Interfaces;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Application.Common.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order, long>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
