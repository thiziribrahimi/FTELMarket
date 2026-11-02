namespace FTELMarket.Infrastructure
{
    using Microsoft.EntityFrameworkCore;


    namespace FTELMarket.Infrastructure
    {
        public class FtelMarketDbContext : DbContext
        {
            public FtelMarketDbContext(DbContextOptions<FtelMarketDbContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(FtelMarketDbContext).Assembly);
            }
        }
    }
}
