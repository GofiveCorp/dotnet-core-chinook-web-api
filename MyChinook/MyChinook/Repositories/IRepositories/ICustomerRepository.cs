using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface ICustomerRepository 
    {
        Task<Customer>UpdateAsync(Customer customer);
    }
}
