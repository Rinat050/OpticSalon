using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpticSalon.Auth.Models;

namespace OpticSalon.Auth.Managers
{
    public sealed class OpticSalonSignInManager : SignInManager<OpticSalonUser>
    {
        public OpticSalonSignInManager(UserManager<OpticSalonUser> userManager,
            IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<OpticSalonUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<OpticSalonUser>> logger,
            IAuthenticationSchemeProvider schemes, IUserConfirmation<OpticSalonUser> confirmation) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }
}
