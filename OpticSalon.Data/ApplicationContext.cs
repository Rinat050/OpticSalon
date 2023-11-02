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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandDb>(e => e.ToTable("brand"));
            modelBuilder.Entity<ClientDb>(e => e.ToTable("client"));
            modelBuilder.Entity<ClientPreferencesDb>(e => e.ToTable("client_preferences"));
            modelBuilder.Entity<EyeDataDb>(e => e.ToTable("eye_data"));
            modelBuilder.Entity<ColorDb>(e => e.ToTable("color"));
            modelBuilder.Entity<FrameColorDb>(e => e.ToTable("frame_color"));
            modelBuilder.Entity<FrameDb>(e => e.ToTable("frame"));
            modelBuilder.Entity<FrameMaterialDb>(e => e.ToTable("frame_material"));
            modelBuilder.Entity<FrameSizesDb>(e => e.ToTable("frame_sizes"));
            modelBuilder.Entity<FrameTypeDb>(e => e.ToTable("frame_type"));
            modelBuilder.Entity<LensPackageDb>(e => e.ToTable("lens_package"));
            modelBuilder.Entity<GenderDb>(e => e.ToTable("gender"));
            modelBuilder.Entity<OrderDb>(e => e.ToTable("order"));
            modelBuilder.Entity<PurposeDb>(e => e.ToTable("purpose"));
            modelBuilder.Entity<RecipeDb>(e => e.ToTable("recipe"));
        }

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
