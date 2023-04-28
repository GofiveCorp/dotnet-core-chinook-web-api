using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyChinookContext _db;
        public EmployeeRepository(MyChinookContext dbContext) 
        {
            _db = dbContext;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {           
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }
    }
}
