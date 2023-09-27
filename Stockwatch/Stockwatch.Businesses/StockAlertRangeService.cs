using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockAlertRangeservice {
        void AddStockAlertRange(StockAlertRange StockAlertRange);
        void UpdateStockAlertRange(StockAlertRange StockAlertRange);
        void RemoveStockAlertRange(StockAlertRange StockAlertRange);
        StockAlertRange FetchStockAlertRangeByName(string Name);
        StockAlertRange FetchStockAlertRangeById(int id);
        List<StockAlertRange> GetAll();
    }
    public class StockAlertRangeservice: IStockAlertRangeservice
    {
        private readonly StockwatchDbContext _context;

        public StockAlertRangeservice(StockwatchDbContext context) { _context = context; }

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

        public StockAlertRange FetchStockAlertRangeByName(string Name)
        {
            return GetAll().Find(x => x.StockSymbol.SymbolName == Name);
        }

        public StockAlertRange FetchStockAlertRangeById(int Id)
        {
            return _context.StockAlertRanges.Find(Id);
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
