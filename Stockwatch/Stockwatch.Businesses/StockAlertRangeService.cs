using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockAlertRangeService {
        void AddStockAlertRange(StockAlertRange StockAlertRange);
        void UpdateStockAlertRange(StockAlertRange StockAlertRange);
        void RemoveStockAlertRange(StockAlertRange StockAlertRange);
        StockAlertRange FetchStockAlertRangeByName(string name);
        StockAlertRange FetchStockAlertRangeById(int id);
        List<StockAlertRange> GetAll();
    }
    public class StockAlertRangeService: IStockAlertRangeService
    {
        private readonly StockwatchDbContext _context;

        public StockAlertRangeService(StockwatchDbContext context) => _context = context;
        public void AddStockAlertRange(StockAlertRange StockAlertRange)
        {
            _context.StockAlertRanges.Add(StockAlertRange);
            _context.SaveChanges();
        }

        public void UpdateStockAlertRange(StockAlertRange StockAlertRange)
        {
            _context.Update(StockAlertRange);
            _context.SaveChanges();
        }

        public StockAlertRange FetchStockAlertRangeByName(string name)
        {
            return GetAll().Find(x => x.StockSymbol.SymbolName == name);
        }

        public StockAlertRange FetchStockAlertRangeById(int id)
        {
            return _context.StockAlertRanges.Find(id);
        }

        public List<StockAlertRange> GetAll()
        {
            return _context.StockAlertRanges.ToList();
        }

        public void RemoveStockAlertRange(StockAlertRange StockAlertRange)
        {
            _context.Remove(StockAlertRange);
            _context.SaveChanges();
        }
    }
}
