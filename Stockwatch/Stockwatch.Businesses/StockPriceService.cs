using Stockwatch.Model;
using System.Text.Json;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    { }
    public class StockPriceService: IStockPriceService
    {
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
