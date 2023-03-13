using MyChinook.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{

    public interface IEmployeeRepository : IDisposable
    {
        Task<List<Employee>> GetAllAsync(CancellationToken ct = default);
        Task<Employee> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default);
        Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default);
        Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<List<Employee>> GetDirectReportsAsync(int id, CancellationToken ct = default);
    }

}
