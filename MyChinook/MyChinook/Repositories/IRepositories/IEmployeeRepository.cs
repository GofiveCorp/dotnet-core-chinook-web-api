using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IEmployeeRepository 
    {
        Task<List<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);
    }
}
