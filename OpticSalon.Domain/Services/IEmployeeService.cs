using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IEmployeeService
    {
        public Task<ResultWithData<Employee>> CreateEmployeeAsync(string login, string password, string name,
                                                string surname, string phoneNumber, string address, string role);
        public Task<ResultWithData<List<Employee>>> GetAllEmployeesAsync();
        public Task<ResultWithData<List<MasterOrder>>> GetMasterOrdersAsync(int masterId, DateTime from, DateTime to);
        public Task<ResultWithData<Employee>> GetMasterForOrderAsync();
        public Task<BaseResult> UpdateEmployee(Employee employee);
    }
}
