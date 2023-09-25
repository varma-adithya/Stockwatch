using Microsoft.EntityFrameworkCore;

namespace Stockwatch.Model
{
    public class StockwatchDbContext : DbContext
    {
        public DbSet<StockData> StockDatas { get; set; }
        public DbSet<StockSymbol> StockSymbols { get; set; }

        public StockwatchDbContext(DbContextOptions<StockwatchDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StockData>().HasIndex(x => x.SymbolId).IsUnique();
            modelBuilder.Entity<StockSymbol>().HasIndex(x => x.SymbolName).IsUnique();
        }

    }
}
