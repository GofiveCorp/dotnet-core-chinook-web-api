using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext dbContext): base(dbContext) 
        {
            _db = dbContext;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {           
            _db.Customer.Update(customer);
            await _db.SaveChangesAsync();
            return customer;
        }
    }
}
