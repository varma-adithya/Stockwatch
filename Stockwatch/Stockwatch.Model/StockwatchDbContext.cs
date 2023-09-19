using Microsoft.EntityFrameworkCore;

namespace Stockwatch.Model
{
    public class StockwatchDbContext : DbContext
    {
        public DbSet<Stockdata> Stockdatas { get; set; }

    }
}
