using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OpticSalon.Data.Models;

namespace OpticSalon.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }

        public DbSet<BrandDb> Brands { get; set; } = null!;
        public DbSet<ClientDb> Clients { get; set; } = null!;
        public DbSet<EmployeeDb> Employees { get; set; } = null!;
        public DbSet<ClientPreferencesDb> ClientPreferences { get; set; } = null!;
        public DbSet<EyeDataDb> EyeData { get; set; } = null!;
        public DbSet<ColorDb> Colors { get; set; } = null!;
        public DbSet<FrameColorDb> FrameColors { get; set; } = null!;
        public DbSet<FrameDb> Frames { get; set; } = null!;
        public DbSet<FrameMaterialDb> FrameMaterials { get; set; } = null!;
        public DbSet<FrameSizesDb> FrameSizes { get; set; } = null!;
        public DbSet<FrameTypeDb> FrameTypes { get; set; } = null!;
        public DbSet<LensPackageDb> LensPackages { get; set; } = null!;
        public DbSet<GenderDb> Genders { get; set; } = null!;
        public DbSet<OrderDb> Orders { get; set; } = null!;
        public DbSet<PurposeDb> Purposes { get; set; } = null!;
        public DbSet<RecipeDb> Recipes { get; set; } = null!;

        public class OpticSalonContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
        {
            public ApplicationContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                var connectionString = ("");
                optionsBuilder.UseNpgsql(connectionString,
                    npgsqlOptions => { npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery); });
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.UseSnakeCaseNamingConvention();

                return new ApplicationContext(optionsBuilder.Options);
            }
        }
    }
}
