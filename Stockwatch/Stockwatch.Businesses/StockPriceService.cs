using Stockwatch.Model.Dto;
using System.Text.Json;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    {
        public Task<IntraStockPrice> GetStockPrice(string url);
    }
    public class StockPriceService: IStockPriceService
    {
        public IntraStockPrice _intraStockPrice { get; set; }

        public async Task<IntraStockPrice> GetStockPrice(string url)
        {
            IntraStockPrice stockPrice;

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
