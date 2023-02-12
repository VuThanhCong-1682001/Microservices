using Customer.API.Repositories.Interfaces;
using Customer.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Controllers
{
    public static class CustomersController
    {
        public static void MapGetApi(this WebApplication app)
        {
            app.MapGet("/", () => "Welcome to Customer API");

            app.MapGet("/api/customers", async (ICustomerService customerService) => await customerService.GetCustomersAsync());

            app.MapGet("/api/customers/{userName}", async (ICustomerService customerService, string userName) =>
            {
                var customer = await customerService.GetCustomerByUserName(userName);
                return customer != null ? Results.Ok(customer) : Results.NotFound();
            });
        }
        public static void MapPostApi(this WebApplication app)
        {
            app.MapPost("/api/customers", async (Customer.API.Entities.Customer customer, ICustomerRepository customerRepository) => {
                await customerRepository.CreateAsync(customer);
            });

            app.MapDelete("/api/customers/{id}", async (int id, ICustomerRepository customerRepository) =>
            {
                var customer = await customerRepository
                                    .FindByCondition(x => x.Id.Equals(id))
                                    .FirstOrDefaultAsync();
                if (customer == null) return Results.NotFound();
                await customerRepository.DeleteAsync(customer);

                return Results.NoContent();
            });
        }
    }
}
