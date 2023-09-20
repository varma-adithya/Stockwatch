using Stockwatch.Model;

namespace Stockwatch.Business
{
    public class Stocksymbolservices
    {
        private readonly StockwatchDbContext _context;

        public Stocksymbolservices(StockwatchDbContext context) { _context = context; }

        public void AddStock(Stocksymbol stocksymbol)
        {
            _context.Stocksymbols.Add(stocksymbol);
            _context.SaveChanges();
        }

        public Stocksymbol Fetchstock(int Id)
        {
            return _context.Stocksymbols.Find(Id);
        }

        public List<Stocksymbol> GetAll()
        {
            return _context.Stocksymbols.ToList();
        }

    }
}
