using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockAlertRangeService {
        void AddStockAlertRange(StockAlertRange stockAlertRange);

        void UpdateStockAlertRange(StockAlertRange stockAlertRange);
        
        void RemoveStockAlertRange(StockAlertRange stockAlertRange);
        
        StockAlertRange FetchStockAlertRangeByName(string name);
        
        StockAlertRange FetchStockAlertRangeById(int id);
        
        List<StockAlertRange> GetAll();
    }
    public class StockAlertRangeService: IStockAlertRangeService
    {
        private readonly StockwatchDbContext _context;
        
        public StockAlertRangeService(StockwatchDbContext context) => _context = context;
        
        public void AddStockAlertRange(StockAlertRange stockAlertRange)
        {
            _context.StockAlertRanges.Add(stockAlertRange);
            _context.SaveChanges();
        }
        
        public void UpdateStockAlertRange(StockAlertRange stockAlertRange)
        {
            _context.Update(stockAlertRange);
            _context.SaveChanges();
        }
        
        public StockAlertRange FetchStockAlertRangeByName(string name)
        {
            return _context.StockAlertRanges.FirstOrDefault(x => x.StockSymbol.SymbolName == name);
        }
        
        public StockAlertRange FetchStockAlertRangeById(int id)
        {
            return _context.StockAlertRanges.Find(id);
        }
        public List<StockAlertRange> GetAll()
        {
            return _context.StockAlertRanges.ToList();
        }
        public void RemoveStockAlertRange(StockAlertRange stockAlertRange)
        {
            _context.Remove(stockAlertRange);
            _context.SaveChanges();
        }
    }
}
