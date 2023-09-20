using Microsoft.EntityFrameworkCore;

namespace Stockwatch.Model
{
    public class StockwatchDbContext : DbContext
    {
        public DbSet<Stockdata> Stockdatas { get; set; }
        public DbSet<Stocksymbol> Stocksymbols { get; set; }

        public StockwatchDbContext(DbContextOptions<StockwatchDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stockdata>().HasIndex(x => x.SymbolId).IsUnique();
            modelBuilder.Entity<Stocksymbol>().HasIndex(x => x.SymbolName).IsUnique();

        }

    }
}
