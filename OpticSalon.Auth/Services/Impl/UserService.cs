using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpticSalon.Auth.Models;
using OpticSalon.Auth.ResultMessages;

namespace OpticSalon.Auth.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly OpticSalonIdentityContext _context;
        private readonly UserManager<OpticSalonUser> _userManager;

        public UserService(OpticSalonIdentityContext context, UserManager<OpticSalonUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<DataResult<List<int>>> GetEmployeesUserByRoleAsync(string role)
        {
            try
            {
                var userResult = await _userManager.GetUsersInRoleAsync(role);
                var usersId = userResult.Select(x => x.Id).ToList();

                var res = await _context.UserClaims
                    .Where(x => usersId.Contains(x.UserId) && x.ClaimType == UserClaims.EmployeeId)
                    .Select(x => int.Parse(x.ClaimValue))
                    .ToListAsync();

                return new DataResult<List<int>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new DataResult<List<int>>() 
                {   Success = false, 
                    Description = AuthResults.DefaultError 
                };
            }
        }
    }
}
