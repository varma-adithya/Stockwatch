using Microsoft.EntityFrameworkCore;
using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockAlertRangeService {
        Task AddStockAlertRangeAsync(StockAlertRange stockAlertRange);
        Task UpdateStockAlertRangeAsync(StockAlertRange stockAlertRange);
        Task DeleteStockAlertRangeAsync(StockAlertRange stockAlertRange);
        Task<StockAlertRange?> FetchStockAlertRangeByNameAsync(string name);
        Task<StockAlertRange?> FetchStockAlertRangeByIdAsync(int id);
        Task<List<StockAlertRange>> GetAllAsync();
    }

    public class StockAlertRangeService: IStockAlertRangeService
    {
        private readonly StockwatchDbContext _context;
        
        public StockAlertRangeService(StockwatchDbContext context) => _context = context;
        
        public async Task AddStockAlertRangeAsync(StockAlertRange stockAlertRange)
        {
            try
            {
                await _context.StockAlertRanges.AddAsync(stockAlertRange);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        public async Task UpdateStockAlertRangeAsync(StockAlertRange stockAlertRange)
        {
            _context.Update(stockAlertRange);
            await _context.SaveChangesAsync();
        }

        public Task<StockAlertRange?> FetchStockAlertRangeByNameAsync(string name)
        {
            return _context.StockAlertRanges.SingleOrDefaultAsync(x => x.StockSymbol.SymbolName == name);
        }
        
        public Task<StockAlertRange?> FetchStockAlertRangeByIdAsync(int id)
        {
            return _context.StockAlertRanges.SingleOrDefaultAsync(x=> x.StockSymbol.Id == id);
        }

        public Task<List<StockAlertRange>> GetAllAsync()
        {
            return _context.StockAlertRanges.Include(x => x.StockSymbol).ToListAsync();
        }

        public async Task DeleteStockAlertRangeAsync(StockAlertRange stockAlertRange)
        {
            _context.Remove(stockAlertRange);
            await _context.SaveChangesAsync();
        }

    }
}
