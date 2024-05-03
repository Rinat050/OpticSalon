using Microsoft.AspNetCore.Identity;
using OpticSalon.Auth.Models;
using System.Collections.Concurrent;

namespace OpticSalon.Blazor.Middleware
{
    public class ClientProfileMiddleware
    {
        public static IDictionary<Guid, string> Emails { get; }
        = new ConcurrentDictionary<Guid, string>();

        private readonly RequestDelegate _next;

        public ClientProfileMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<OpticSalonUser> signInManager, UserManager<OpticSalonUser> userManager)
        {
            if (context.Request.Path == "/clientProfile" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]!);
                var email = Emails[key];
                Emails.Remove(key);

                var user = await userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    await signInManager.SignInAsync(user, true);
                }

                context.Response.Redirect("/clientProfile");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}

