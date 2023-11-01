using Microsoft.AspNetCore.Identity;
using OpticSalon.Auth.Models;
using OpticSalon.Auth.ResultMessages;
using System.Security.Claims;

namespace OpticSalon.Auth.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<OpticSalonUser> _userManager;
        private readonly OpticSalonIdentityContext _context;

        public AuthService(UserManager<OpticSalonUser> userManager, OpticSalonIdentityContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AuthResult> ChangeUserPassword(string login, string oldPassword, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(login);
                if (user == null)
                {
                    return new AuthResult() { Success = false, Description = AuthResults.NotFounded };
                }

                var res = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

                if (!res.Succeeded)
                {
                    return new AuthResult() { Success = false, Description = AuthResults.InvalidCurrentPassword };
                }

                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, newPassword);

                return new AuthResult() { Success = true, Description = AuthResults.SuccessPasswordUpdate };
            }
            catch
            {
                return new AuthResult() { Success = false, Description = AuthResults.DefaultError };
            }
        }

        public async Task<AuthResult> RegisterUser(string login, string password, string role, int createdEntityId)
        {
            try
            {
                if (await _userManager.FindByEmailAsync(login) is not null)
                {
                    return new AuthResult() { Success = false, Description = AuthResults.UserWithEmailExist };
                }

                var user = new OpticSalonUser() { Email = login, UserName = login};

                var res = await _userManager.CreateAsync(user);

                if (!res.Succeeded)
                {
                    return new AuthResult() { Success = false, Description = AuthResults.DefaultError };
                }

                if (role == Role.Client)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    await _userManager.AddClaimAsync(user, new Claim(UserClaims.ClientId, createdEntityId.ToString()));
                }
                else
                {
                    return new AuthResult() { Success = false, Description = AuthResults.InvalidRole };
                }

                var savedUser = await _userManager.FindByEmailAsync(login);

                await _userManager.RemovePasswordAsync(savedUser);
                await _userManager.AddPasswordAsync(savedUser, password);

                return new AuthResult() { Success = true, Description = AuthResults.SuccessRegister };
            }
            catch
            {
                return new AuthResult() { Success = false, Description = AuthResults.DefaultError };
            }
        }
    }
}