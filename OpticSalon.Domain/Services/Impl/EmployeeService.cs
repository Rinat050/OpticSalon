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
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public EmployeeService(IEmployeeRepository employeeRepository, 
                IAuthService authService, IOrderRepository orderRepository, IUserService userService)
        {
            _employeeRepository = employeeRepository;
            _authService = authService;
            _orderRepository = orderRepository;
            _userService = userService;
        }

        public async Task<ResultWithData<Employee>> CreateEmployeeAsync(string login, string password, string name,
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

                var createdEmployee = await _employeeRepository.AddEmployeeAsync(newEmployee);

                var registerRes = await _authService.RegisterUser(login, password, role, createdEmployee.Id);

                if (!registerRes.Success)
                {
                    await _employeeRepository.DeleteEmployeeAsync(createdEmployee);
                    return new ResultWithData<Employee>
                    {
                        Success = false,
                        Description = registerRes.Description
                    };
                }

                return new ResultWithData<Employee>()
                {
                    Success = true,
                    Description = SuccessMessages.EmployeeServiceMessages.SuccessCreated,
                    Data = createdEmployee
                };
            }
            catch
            {
                return new ResultWithData<Employee>() { Success = false, Description = DefaultErrors.ServerError };
            }
        }

        public async Task<ResultWithData<List<Employee>>> GetAllEmployeesAsync()
        {
            try
            {
                var list = await _employeeRepository.GetAllEmployeesAsync();

                return new ResultWithData<List<Employee>>()
                {
                    Success = true,
                    Data = list
                };
            }
            catch
            {
                return new ResultWithData<List<Employee>>() { Success = false, Description = DefaultErrors.ServerError };
            }
        }

        public async Task<ResultWithData<Employee>> GetMasterIdForOrderAsync()
        {
            try
            {
                var mastersOrdersCount = await _orderRepository.GetMastersOrdersCount();
                var allMastersRes = await _userService.GetEmployeesUserByRoleAsync(Role.Master);

                if (!allMastersRes.Success)
                {
                    return new ResultWithData<Employee>()
                    {
                        Success = false,
                        Description = allMastersRes.Description
                    };
                }

                if (allMastersRes.Data.Count == 0)
                {
                    return new ResultWithData<Employee>()
                    {
                        Success = false,
                        Description = ErrorMessages.EmployeeServiceMessages.MasterNotFounded
                    };
                }

                foreach(var masterId in allMastersRes.Data)
                {
                    var masterOrders = mastersOrdersCount
                                            .FirstOrDefault(x => x.MasterId == masterId);

                    if (masterOrders == null)
                    {
                        var res = await _employeeRepository.GetEmployeeByIdAsync(masterId);

                        return new ResultWithData<Employee>()
                        {
                            Success = true,
                            Data = res
                        };
                    }
                }

                var minCount = mastersOrdersCount.Min(x => x.Count);

                var resId = mastersOrdersCount.FirstOrDefault(x => x.Count == minCount)!.MasterId;
                var master = await _employeeRepository.GetEmployeeByIdAsync(resId);

                return new ResultWithData<Employee>()
                {
                    Success = true,
                    Data = master
                };
            }
            catch
            {
                return new ResultWithData<Employee>() 
                {   Success = false, 
                    Description = DefaultErrors.ServerError 
                };
            }
        }
    }
}
