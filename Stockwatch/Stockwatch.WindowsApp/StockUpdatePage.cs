
using Stockwatch.Background;

namespace Stockwatch.WindowsApp
{
    public interface IStockUpdatePag { }
    public class StockUpdatePage
    {
        private Worker worker;
        public StockUpdatePage(Worker _worker) 
        { worker = _worker; }

    }
}
