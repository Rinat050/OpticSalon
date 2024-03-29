using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IEmployeeService
    {
        public Task<ResultWithData<Employee>> CreateEmployeeAsync(string login, string password, string name,
                                                string surname, string phoneNumber, string address, string role);
        public Task<ResultWithData<List<Employee>>> GetAllEmployeesAsync();
    }
}
