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
                        return stockPrice;
                    }
                    else
                    {
                        return null;
                    }

                    //For Debug Puposes - API request limit
                    //return new IntraStockPrice
                    //{
                    //    GlobalQuote = new GlobalQuote
                    //    {
                    //        Symbol = "AAPL",
                    //        Open = 10,
                    //        High = 100,
                    //        Low = 5,
                    //        Price = 35,
                    //        Volume = 10000,
                    //        LatestTradingDay = DateTime.Now,
                    //        PreviousClose = 10,
                    //        Change = 12,
                    //        PercentChange = "0.8%"
                    //    }
                    //};

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


    }
}
