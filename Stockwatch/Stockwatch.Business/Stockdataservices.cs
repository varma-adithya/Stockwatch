using Stockwatch.Model;

namespace Stockwatch.Business
{
    public interface IStockdataservices { }
    public class Stockdataservices: IStockdataservices
    {
        private readonly StockwatchDbContext _context;

        public Stockdataservices(StockwatchDbContext context) { _context = context; }

        public void AddStock(Stockdata stockdata)
        {
            _context.Stockdatas.Add(stockdata);
            _context.SaveChanges();
        }

        public Stockdata Fetchstock(int Id)
        {
            return _context.Stockdatas.Find(Id);
        }

        public List<Stockdata> GetAll()
        {
            return _context.Stockdatas.ToList();
        }
    }
}
