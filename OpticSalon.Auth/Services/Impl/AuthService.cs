using Microsoft.AspNetCore.Identity;
using OpticSalon.Auth.Models;
using OpticSalon.Auth.ResultMessages;
using System.Security.Claims;

namespace OpticSalon.Auth.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<OpticSalonUser> _userManager;
        private readonly SignInManager<OpticSalonUser> _signInManager;
        private readonly OpticSalonIdentityContext _context;

        public AuthService(UserManager<OpticSalonUser> userManager, 
            SignInManager<OpticSalonUser> signInManager, OpticSalonIdentityContext context)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<AuthResult> ChangeUserEmail(string oldEmail, string newEmail)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(oldEmail);

                if (user == null)
                {
                    return new AuthResult() { Success = false, Description = AuthResults.NotFounded };
                }

                var existUser = await _userManager.FindByEmailAsync(newEmail);

                if (existUser != null && existUser.Id != user.Id)
                {
                    return new AuthResult() { Success = false, Description = AuthResults.UserWithEmailExist };
                }

                user.Email = newEmail;
                user.UserName = newEmail;
                var res = await _userManager.UpdateAsync(user);

                if (res.Succeeded)
                {
                    return new AuthResult() { Success = true, Description = AuthResults.SuccessEmailUpdate };
                }

                return new AuthResult() { Success = false, Description = AuthResults.DefaultError };
            }
            catch
            {
                return new AuthResult() { Success = false, Description = AuthResults.DefaultError };
            }
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
                else if (role == Role.Admin || role == Role.Master || role == Role.Manager)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    await _userManager.AddClaimAsync(user, new Claim(UserClaims.EmployeeId, createdEntityId.ToString()));
                }
                else
                {
                    return new AuthResult() { Success = false, Description = AuthResults.InvalidRole };
                }

                await _userManager.AddPasswordAsync(user, password);

                return new AuthResult() { Success = true, Description = AuthResults.SuccessRegister };
            }
            catch
            {
                return new AuthResult() { Success = false, Description = AuthResults.DefaultError };
            }
        }
    }
}