﻿using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {      
        Task<Employee> UpdateAsync(Employee employee);              
    }
}
