using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IEmployeeRepository 
    {      
        Task<Employee> UpdateAsync(Employee employee);              
    }
}
