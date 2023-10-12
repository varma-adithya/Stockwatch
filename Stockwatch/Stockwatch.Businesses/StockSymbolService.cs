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
        
        public void AddStockSymbol(StockSymbol stockSymbol)
        {
            _context.StockSymbols.Add(stockSymbol);
            _context.SaveChanges();
        }
        
        public StockSymbol FetchStockSymbolByName(string name)
        {
            return GetAll().Find(s => s.SymbolName == name);
        }
        
        public StockSymbol FetchStockSymbolById(int id)
        {
            return _context.StockSymbols.Find(id);
        }
        
        public void DeleteStockSymbol(StockSymbol stockSymbol)
        {
            _context.Remove(stockSymbol);
        }
        
        public List<StockSymbol> GetAll()
        {
            return _context.StockSymbols.ToList();
        }
    }
}
