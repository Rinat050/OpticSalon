using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpticSalon.Auth.Models;

namespace OpticSalon.Auth
{
    internal sealed class OpticSalonIdentityContext : IdentityDbContext<OpticSalonUser, OpticSalonRole, int>
    {
        public OpticSalonIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
