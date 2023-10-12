using Stockwatch.Model;
using Stockwatch.Model.Dto;
using System.Text.Json;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    {
        public Task<IntraStockPrice> GetStockPrice(AlphaVantageAPI UrlOptions);
    }
    public class StockPriceService: IStockPriceService
    {
        public IntraStockPrice _intraStockPrice { get; set; }

        public async Task<IntraStockPrice> GetStockPrice(AlphaVantageAPI UrlOptions)
        {
            IntraStockPrice stockPrice;
            string url = UrlOptions.ApiUrl
                    .Replace("YOUR_SYMBOL_NAME", UrlOptions.SymbolName)
                    .Replace("YOUR_API_KEY", UrlOptions.ApiKey);
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
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        };
                        stockPrice = JsonSerializer.Deserialize<IntraStockPrice>(jsonContent)!;
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
