using Microsoft.EntityFrameworkCore;
using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockSymbolService
    {
        Task AddStockSymbolAsync(StockSymbol stockSymbol);
        Task<StockSymbol?> FetchStockSymbolByIdAsync(int id);
        Task<StockSymbol?> FetchStockSymbolByNameAsync(string name);
        Task<List<StockSymbol>> GetAllAsync();
        Task DeleteStockSymbolAsync(StockSymbol stockSymbol);
    }

    public class StockSymbolService : IStockSymbolService
    {
        private readonly StockwatchDbContext _context;
        
        public StockSymbolService(StockwatchDbContext context) { _context = context; }
        
        public async Task AddStockSymbolAsync(StockSymbol stockSymbol)
        {
            _context.StockSymbols.Add(stockSymbol);
            await _context.SaveChangesAsync();
        }
        
        public Task<StockSymbol?> FetchStockSymbolByNameAsync(string name)
        {
            return _context.StockSymbols.SingleOrDefaultAsync(s => s.SymbolName == name);
        }
        
        public Task<StockSymbol?> FetchStockSymbolByIdAsync(int id)
        {
            return _context.StockSymbols.SingleOrDefaultAsync(x=> x.Id == id);
        }
        
        public async Task DeleteStockSymbolAsync(StockSymbol stockSymbol)
        {
            _context.Remove(stockSymbol);
            await _context.SaveChangesAsync();
        }
        
        public Task<List<StockSymbol>> GetAllAsync()
        {
            return _context.StockSymbols.ToListAsync();
        }
    }
}
