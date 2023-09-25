using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockSymbolService
    {
        void AddStock(StockSymbol stocksymbol);
        StockSymbol FetchstockwId(int id);
        StockSymbol FetchstockwName(string Name);
        List<StockSymbol> GetAll();

        void DeleteStock(StockSymbol stocksymbol);
    }
    public class StockSymbolService : IStockSymbolService
    {
        private readonly StockwatchDbContext _context;

        public StockSymbolService(StockwatchDbContext context) { _context = context; }

        public void AddStock(StockSymbol stocksymbol)
        {
            _context.StockSymbols.Add(stocksymbol);
            _context.SaveChanges();
        }

        public StockSymbol FetchstockwName(string Name)
        {
            return GetAll().Find(s => s.SymbolName == Name);
        }

        public StockSymbol FetchstockwId(int Id)
        {
            return _context.StockSymbols.Find(Id);
        }

        public void DeleteStock(StockSymbol stocksymbol)
        {
            _context.Remove(stocksymbol);
        }

        public List<StockSymbol> GetAll()
        {
            return _context.StockSymbols.ToList();
        }

    }
}
