using Stockwatch.Model;
using System.Text.Json;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    { }
    public class StockPriceService: IStockPriceService
    {
        //private readonly ILogger<Worker> _logger;
        public IntraStockPrice intraStockprice { get; set; }

        public StockPriceService()
        {
        }


        public async Task<IntraStockPrice> GetStockPrice(string URL)
        {
            IntraStockPrice StockPrice;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(URL);

                    if (response.IsSuccessStatusCode)
                    {

                        //_logger.LogInformation("Api call successfull!");
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        var serializeOptions = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        };
                        StockPrice = JsonSerializer.Deserialize<IntraStockPrice>(jsonContent)!;
                        Console.WriteLine(StockPrice.Symbol);
                        return StockPrice;
                        //if (StockPrice.Price >= StockAlertRange.UpperLimit)
                        //{
                        //    _logger.LogInformation("Sell the stock");
                        //}
                        //else if(StockPrice.Price <= StockAlertRange.LowerLimit)
                        //{
                        //    _logger.LogInformation("Buy more stock!");
                        //}
                        //else { _logger.LogInformation("Keep the stock"); }

                        //Console.WriteLine("Success");
                    }

                    else
                    {
                        //_logger.LogInformation("Api call failed!");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    //_logger.LogInformation(ex.Message);
                    return null;
                }
            }


        }


    }
}
