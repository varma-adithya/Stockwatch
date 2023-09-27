using Stockwatch.Business;

namespace Stockwatch.WindowsApp
{
    public interface IStockUpdatePag { }
    public class StockUpdatePage
    {
        private IStockPriceService priceService;
        public StockUpdatePage(IStockPriceService _priceService) 
        {
            priceService = _priceService; 
        }


    }
}
