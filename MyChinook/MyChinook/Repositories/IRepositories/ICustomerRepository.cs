using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface ICustomerRepository 
    {
        Task<List<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken);
    }
}
