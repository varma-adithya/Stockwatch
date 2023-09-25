using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockDataservice {
        void AddStock(StockData StockData);
        void UpdateStock(StockData StockData);
        void RemoveStock(StockData StockData);
        StockData FetchName(string Name);
        StockData Fetchstock(int id);
        List<StockData> GetAll();
    }
    public class StockDataservice: IStockDataservice
    {
        private readonly StockwatchDbContext _context;

        public StockDataservice(StockwatchDbContext context) { _context = context; }

        public void AddStock(StockData StockData)
        {
            _context.StockDatas.Add(StockData);
            _context.SaveChanges();
        }

        public void UpdateStock(StockData StockData)
        {
            _context.Update(StockData);
            _context.SaveChanges();
        }

        public StockData FetchName(string Name)
        {
            return GetAll().Find(x => x.StockSymbol.SymbolName == Name);
        }

        public StockData Fetchstock(int Id)
        {
            return _context.StockDatas.Find(Id);
        }

        public List<StockData> GetAll()
        {
            return _context.StockDatas.ToList();
        }

        public void RemoveStock(StockData StockData)
        {
            _context.Remove(StockData);
            _context.SaveChanges();
        }
    }
}
