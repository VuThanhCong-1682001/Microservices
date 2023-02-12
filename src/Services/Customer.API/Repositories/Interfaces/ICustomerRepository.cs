using Contracts.Domains.Interfaces;
using Customer.API.Persistence;
using Infrastructure.Common;

namespace Customer.API.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Entities.Customer, int, CustomerContext>
    {
        Task<Entities.Customer> GetCustomerByUserNameAsync(string userName);
        Task<IEnumerable<Entities.Customer>> GetCustomersAsync();
    }
}
