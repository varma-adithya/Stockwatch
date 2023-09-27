using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockSymbolService
    {
        void AddStockAlertRangeSymbol(StockSymbol stocksymbol);
        StockSymbol FetchStockAlertRangeByIdSymbolById(int id);
        StockSymbol FetchStockAlertRangeByIdSymbolByName(string Name);
        List<StockSymbol> GetAll();

        void DeleteStock(StockSymbol stocksymbol);
    }
    public class StockSymbolService : IStockSymbolService
    {
        private readonly StockwatchDbContext _context;

        public StockSymbolService(StockwatchDbContext context) { _context = context; }

        public void AddStockAlertRangeSymbol(StockSymbol stocksymbol)
        {
            _context.StockSymbols.Add(stocksymbol);
            _context.SaveChanges();
        }

        public StockSymbol FetchStockAlertRangeByIdSymbolByName(string Name)
        {
            return GetAll().Find(s => s.SymbolName == Name);
        }

        public StockSymbol FetchStockAlertRangeByIdSymbolById(int Id)
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
