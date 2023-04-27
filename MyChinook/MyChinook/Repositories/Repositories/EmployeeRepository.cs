using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly MyChinookContext _db;
        public EmployeeRepository(MyChinookContext dbContext): base(dbContext) 
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
