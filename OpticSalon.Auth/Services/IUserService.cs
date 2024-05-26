using OpticSalon.Auth.Models;

namespace OpticSalon.Auth.Services
{
    public interface IUserService
    {
        public Task<DataResult<List<int>>> GetEmployeesUserByRoleAsync(string role);
        public Task<DataResult<string>> GetClientEmailAsync(int clientId);
    }
}
