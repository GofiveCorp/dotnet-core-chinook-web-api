using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class CustomerRepository :  ICustomerRepository
    {
        private readonly MyChinookContext db;
        public CustomerRepository(MyChinookContext dbContext)
        {
            db = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken)
        {
            var customer = await db.Customers.ToListAsync(cancellationToken);
            return customer;
        }
    }
}
