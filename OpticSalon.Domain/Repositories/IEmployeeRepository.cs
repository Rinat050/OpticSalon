using OpticSalon.Domain.Models;

namespace OpticSalon.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmployee(Employee employee);
        public Task DeleteEmployee(Employee employee);
    }
}
