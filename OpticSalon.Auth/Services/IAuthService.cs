using OpticSalon.Auth.Models;

namespace OpticSalon.Auth.Services
{
    public interface IAuthService
    {
        public Task<AuthResult> RegisterUser(string login, string password, string role, int createdEntityId);
        public Task<AuthResult> ChangeUserPassword(string login, string oldPassword, string newPassword);
        public Task<AuthResult> ChangeUserPassword(string login, string newPassword);
        public Task<AuthResult> ChangeUserEmail(string oldEmail, string newEmail);
        public Task<AuthResult> ChangeUserRole(string login, string newRole);
    }
}
