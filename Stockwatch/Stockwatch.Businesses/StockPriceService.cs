using Microsoft.Extensions.Options;
using Stockwatch.Model;
using System.Text.Json;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    { 
        public Task<IntraStockPrice?> GetStockPrice(AlphaVantageAPI URLoptions); 
    }

    public class StockPriceService: IStockPriceService
    {
        //private readonly ILogger<Worker> _logger;
        public IntraStockPrice? intraStockprice { get; set; }

        public async Task<IntraStockPrice?> GetStockPrice(AlphaVantageAPI URLoptions)
        {

            string URL = URLoptions.URL
                                .Replace("YOUR_SYMBOL_NAME", URLoptions.SymbolName)
                                .Replace("YOUR_API_KEY", URLoptions.ApiKey);

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
