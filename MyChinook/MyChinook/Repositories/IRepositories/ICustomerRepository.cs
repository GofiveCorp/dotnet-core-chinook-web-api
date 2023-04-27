using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer>UpdateAsync(Customer customer);
    }
}
