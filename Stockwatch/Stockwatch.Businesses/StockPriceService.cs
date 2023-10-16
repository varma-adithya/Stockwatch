using Stockwatch.Model;
using Stockwatch.Model.Dto;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    {
        public Task<IntraStockPrice> GetStockPrice(AlphaVantageAPI urlOptions);
    }
    public class StockPriceService: IStockPriceService
    {
        public IntraStockPrice _intraStockPrice { get; set; }

        public async Task<IntraStockPrice> GetStockPrice(AlphaVantageAPI urlOptions)
        {
            string url = urlOptions.ApiUrl
                    .Replace("YOUR_SYMBOL_NAME", urlOptions.SymbolName)
                    .Replace("YOUR_API_KEY", urlOptions.ApiKey);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        var serializeOptions = new JsonSerializerOptions
                        {

                            NumberHandling = JsonNumberHandling.AllowReadingFromString,
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            PropertyNameCaseInsensitive = true,
                        };

                        IntraStockPrice stockPrice = JsonSerializer.Deserialize<IntraStockPrice>(jsonContent, serializeOptions);
                        Console.WriteLine(stockPrice.GlobalQuote.High);
                        return stockPrice;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


    }
}
