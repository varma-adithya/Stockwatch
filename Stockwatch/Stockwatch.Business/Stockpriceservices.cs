using Newtonsoft.Json.Linq;
using Stockwatch.Model;

namespace Stockwatch.Business
{
    public class Stockpriceservices
    {
        private readonly ILogger<Worker> _logger;
        public IntraStockprice intraStockprice { get; set; }

        public Stockpriceservices(ILogger<Worker> logger)
        {
                _logger = logger;
        }


        public async void GetStockprice(Stockdata stockdata)
        {
            var apiKey = "EO4BB53HAZMW6TDW";
            string apiUrl = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={stockdata.Stocksymbol.SymbolName}&apikey={apiKey}";
            IntraStockprice stockPrice;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("Api call successfull!");
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(jsonContent);
                        JObject globalQuote = (JObject)data["Global Quote"];
                        stockPrice = globalQuote.ToObject<IntraStockprice>();

                        if (stockPrice.Price >= stockdata.Upperlimit)
                        {
                            _logger.LogInformation("Sell the stock");
                        }
                        else if(stockPrice.Price <= stockdata.Lowerlimit)
                        {
                            _logger.LogInformation("Buy more stock!");
                        }
                        else { _logger.LogInformation("Keep the stock"); }

                        Console.WriteLine("Success");
                        Console.WriteLine(stockPrice.Symbol);
                        Console.WriteLine(stockPrice.Price);
                    }

                    else
                    {
                        _logger.LogInformation("Api call failed!");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }


        }


    }
}
