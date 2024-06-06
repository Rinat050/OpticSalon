using OpticSalon.Domain.Models;
using OpticSalon.Domain.Models.Report;

namespace OpticSalon.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task DeleteEmployeeAsync(Employee employee);
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task UpdateEmployee(Employee employee);
        public Task<List<EmployeeReportItem>> GetReport(DateTime start, DateTime end);
    }
}
