using Microsoft.AspNetCore.Identity;
using OpticSalon.Auth.Models;
using OpticSalon.Blazor.Data.Credentials;
using System.Collections.Concurrent;

namespace OpticSalon.Blazor.Middleware
{
    public class AuthenticationMiddleware
    {
        public static IDictionary<Guid, LoginCredentials> Logins { get; }
        = new ConcurrentDictionary<Guid, LoginCredentials>();

        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<OpticSalonUser> signInManager, UserManager<OpticSalonUser> userManager)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]!);
                var info = Logins[key];
                Logins.Remove(key);

                var result = await signInManager.PasswordSignInAsync(info.Email, info.Password,
                    info.RememberMe, lockoutOnFailure: false);

                info.Password = string.Empty;

                if (!result.Succeeded)
                {
                    context.Response.Redirect("/login");
                    return;
                }

                var user = await userManager.FindByEmailAsync(info.Email);

                var roles = await userManager.GetRolesAsync(user);

                switch (roles.First())
                {
                    case Role.Master:
                        context.Response.Redirect("/masterOrders");
                        break;
                    default:
                        context.Response.Redirect("/");
                        break;
                }
            }
            else if (context.Request.Path == "/logout")
            {
                await signInManager.SignOutAsync();
                context.Response.Redirect("/");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
