using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockSymbolService
    {
        void AddStockSymbol(StockSymbol stockSymbol);
        StockSymbol FetchStockSymbolById(int id);
        StockSymbol FetchStockSymbolByName(string name);
        List<StockSymbol> GetAll();
        void DeleteStockSymbol(StockSymbol stockSymbol);
    }
    public class StockSymbolService : IStockSymbolService
    {
        private readonly StockwatchDbContext _context;
        
        public StockSymbolService(StockwatchDbContext context) { _context = context; }
        
        public async void AddStockSymbol(StockSymbol stockSymbol)
        {
            _context.StockSymbols.Add(stockSymbol);
            await _context.SaveChangesAsync();
        }
        
        public StockSymbol FetchStockSymbolByName(string name)
        {
            return GetAll().Find(s => s.SymbolName == name);
        }
        
        public StockSymbol FetchStockSymbolById(int id)
        {
            return _context.StockSymbols.Find(id);
        }
        
        public async void DeleteStockSymbol(StockSymbol stockSymbol)
        {
            _context.Remove(stockSymbol);
            await _context.SaveChangesAsync();
        }
        
        public List<StockSymbol> GetAll()
        {
            return _context.StockSymbols.ToList();
        }
    }
}
