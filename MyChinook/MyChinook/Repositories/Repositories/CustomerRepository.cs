using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly MyChinookContext _db;
        public CustomerRepository(MyChinookContext dbContext): base(dbContext) 
        {
            _db = dbContext;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {           
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
            return customer;
        }
    }
}
