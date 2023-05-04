using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyChinookContext db;
        public EmployeeRepository(MyChinookContext dbContext) 
        {
            db = dbContext;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            var employee = await db.Employees.ToListAsync(cancellationToken);
            return employee;
        }
    }
}
