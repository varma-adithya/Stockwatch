using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public interface IStockSymbolPage
    {
        void AddSymbol();
        List<string> GetSymbolList();
        StockSymbol FetchStockSymbolByIdAsync(int id);
        StockSymbol FetchStockSymbolByNameAsync(string name);
    }
    public class StockSymbolPage : IStockSymbolPage
    {
        public IStockSymbolService _stockSymbolService;
        
        public StockSymbolPage(IStockSymbolService stocksymbolservice) {
            _stockSymbolService = stocksymbolservice;
        }
        public void AddSymbol()
        {
            if (_stockSymbolService.FetchStockSymbolByNameAsync("AAPL") == null)
            {
                _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "AAPL" });
            }
            if (_stockSymbolService.FetchStockSymbolByNameAsync("IBM") == null)
            {
                _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "IBM" });
            }
            if (_stockSymbolService.FetchStockSymbolByNameAsync("BAC") == null)
            {
                _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "BAC" });
            }
            if (_stockSymbolService.FetchStockSymbolByNameAsync("GOOGL") == null)
            {
                _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "GOOGL" });
            }
            if (_stockSymbolService.FetchStockSymbolByNameAsync("AMZN") == null)
            {
                _stockSymbolService.AddStockSymbolAsync(new StockSymbol { SymbolName = "AMZN" });
            }

        }

        public StockSymbol FetchStockSymbolByIdAsync(int id)
        {
            if (id != null)
            {
                var stockSymbol = _stockSymbolService.FetchStockSymbolByIdAsync(id).Result;
                if (stockSymbol != null)
                {
                    return stockSymbol;
                }
                else
                    return null;
                //No stock with given id found
            }
            else
                return null;
            //Id not valid
        }

        public StockSymbol FetchStockSymbolByNameAsync(string name)
        {
            if (name != null)
            {
                var stockSymbol = _stockSymbolService.FetchStockSymbolByNameAsync(name).Result;
                if (stockSymbol != null)
                {
                    return stockSymbol;
                }
                else
                    return null;
                //No stock with given name found
            }
            else
                return null;
            //Name not valid
        }

        public List<string> GetSymbolList() 
        {
            var stockSymbols = _stockSymbolService.GetAllAsync().Result;
            if(!stockSymbols.Any())
            {
                return null;
                //List is empty
            }
            else
            return stockSymbols.Select(ss => ss.SymbolName).ToList();
        }
    }
}
