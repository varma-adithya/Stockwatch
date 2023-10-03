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

        public StockPriceService()
        {
        }

        public async Task<IntraStockPrice> GetStockPrice(string url)
        {
            IntraStockPrice StockPrice;
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
                        StockPrice = JsonSerializer.Deserialize<IntraStockPrice>(jsonContent)!;
                        Console.WriteLine(StockPrice.Symbol);
                        return StockPrice;
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
