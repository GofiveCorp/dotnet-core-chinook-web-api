using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;


namespace MyChinook.Repositories.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext dbContext): base(dbContext) 
        {
            _db = dbContext;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {           
            _db.Employee.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }
    }
}
