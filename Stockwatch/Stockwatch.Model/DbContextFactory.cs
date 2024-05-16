using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Stockwatch.Model
{
    public class StockwatchDbContextFactory : IDesignTimeDbContextFactory<StockwatchDbContext>
    {
        public StockwatchDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<StockwatchDbContext>();
            var connectionString = $"Data Source={DbFileLocation.GetDbFileLocation()}";
            builder.UseSqlite(connectionString);
            return new StockwatchDbContext(builder.Options);
        }
    }
}