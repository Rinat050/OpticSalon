using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OpticSalon.Auth.Models;

namespace OpticSalon.Auth
{
    public sealed class OpticSalonIdentityContext : IdentityDbContext<OpticSalonUser, OpticSalonRole, int>
    {
        public OpticSalonIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }

    public class OpticSalonContextFactory : IDesignTimeDbContextFactory<OpticSalonIdentityContext>
    {
        public OpticSalonIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OpticSalonIdentityContext>();
            optionsBuilder.UseNpgsql("");

            return new OpticSalonIdentityContext(optionsBuilder.Options);
        }
    }   
}
