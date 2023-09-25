using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockDataService {
        void AddStock(Stockdata StockData);
        void UpdateStock(Stockdata StockData);
        void RemoveStock(Stockdata StockData);
        Stockdata FetchName(string Name);
        Stockdata Fetchstock(int id);
        List<Stockdata> GetAll();
    }
    public class StockDataService: IStockDataService
    {
        private readonly StockwatchDbContext _context;

        public StockDataService(StockwatchDbContext context) { _context = context; }

        public void AddStock(Stockdata StockData)
        {
            _context.Stockdatas.Add(StockData);
            _context.SaveChanges();
        }

        public void UpdateStock(Stockdata StockData)
        {
            _context.Update(StockData);
            _context.SaveChanges();
        }

        public Stockdata FetchName(string Name)
        {
            return GetAll().Find(x => x.StockSymbol.SymbolName == Name);
        }

        public Stockdata Fetchstock(int Id)
        {
            return _context.Stockdatas.Find(Id);
        }

        public List<Stockdata> GetAll()
        {
            return _context.Stockdatas.ToList();
        }

        public void RemoveStock(Stockdata StockData)
        {
            _context.Remove(StockData);
            _context.SaveChanges();
        }
    }
}
