using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IEmployeeService
    {
        public Task<ResultWithData<Employee>> CreateEmployee(string login, string password, string name,
                                    string surname, string phoneNumber, string address, string role);
    }
}
