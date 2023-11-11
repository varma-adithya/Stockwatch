using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public interface IStockSymbolPage
    {
        void AddSymbol();
        List<string> GetSymbolList();
        StockSymbol FetchStockSymbolById(int id);
        StockSymbol FetchStockSymbolByName(string name);
    }
    public class StockSymbolPage : IStockSymbolPage
    {
        public IStockSymbolService _stockSymbolService;
        
        public StockSymbolPage(IStockSymbolService stocksymbolservice) {
            _stockSymbolService = stocksymbolservice;
        }
        public void AddSymbol()
        {
            if (_stockSymbolService.FetchStockSymbolByName("AAPL") == null)
            {
                _stockSymbolService.AddStockSymbol(new StockSymbol { SymbolName = "AAPL" });
            }
            if (_stockSymbolService.FetchStockSymbolByName("IBM") == null)
            {
                _stockSymbolService.AddStockSymbol(new StockSymbol { SymbolName = "IBM" });
            }
            if (_stockSymbolService.FetchStockSymbolByName("BAC") == null)
            {
                _stockSymbolService.AddStockSymbol(new StockSymbol { SymbolName = "BAC" });
            }
            if (_stockSymbolService.FetchStockSymbolByName("GOOGL") == null)
            {
                _stockSymbolService.AddStockSymbol(new StockSymbol { SymbolName = "GOOGL" });
            }
            if (_stockSymbolService.FetchStockSymbolByName("AMZN") == null)
            {
                _stockSymbolService.AddStockSymbol(new StockSymbol { SymbolName = "AMZN" });
            }

        }

        public StockSymbol FetchStockSymbolById(int id)
        {
            return _stockSymbolService.FetchStockSymbolById(id);
        }

        public StockSymbol FetchStockSymbolByName(string name)
        {
        return _stockSymbolService.FetchStockSymbolByName(name);
        }

        public List<string> GetSymbolList() 
        {
            var stockSymbols = _stockSymbolService.GetAll();
            return stockSymbols.Select(ss => ss.SymbolName).ToList();
        }
    }
}
