using OpticSalon.Auth.Models;
using OpticSalon.Auth.Services;
using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

namespace OpticSalon.Domain.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAuthService _authService;

        public EmployeeService(IEmployeeRepository employeeRepository, IAuthService authService)
        {
            _employeeRepository = employeeRepository;
            _authService = authService;
        }

        public async Task<ResultWithData<Employee>> CreateEmployee(string login, string password, string name,
                                                string surname, string phoneNumber, string address, string role)
        {
            try
            {
                var newEmployee = new Employee()
                {
                    Name = name,
                    Surname = surname,
                    PhoneNumber = phoneNumber,
                    Address = address
                };

                var createdEmployee = await _employeeRepository.AddEmployee(newEmployee);

                var registerRes = await _authService.RegisterUser(login, password, role, createdEmployee.Id);

                if (!registerRes.Success)
                {
                    await _employeeRepository.DeleteEmployee(createdEmployee);
                    return new ResultWithData<Employee>
                    {
                        Success = false,
                        Description = registerRes.Description
                    };
                }

                return new ResultWithData<Employee>()
                {
                    Success = true,
                    Description = EmployeeServiceMessages.SuccessCreated,
                    Data = createdEmployee
                };
            }
            catch
            {
                return new ResultWithData<Employee>() { Success = false, Description = DefaultErrors.ServerError };
            }
        }
    }
}
