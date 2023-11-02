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
