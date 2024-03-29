﻿using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task DeleteEmployeeAsync(Employee employee);
    }
}
