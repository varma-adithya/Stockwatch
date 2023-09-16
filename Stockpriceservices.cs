using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stockwatch
{
    public class Stockpriceservices
    {
        private readonly ILogger<Worker> _logger;
        public IntraStockprice intraStockprice { get; set; }

        public Stockpriceservices(ILogger<Worker> logger)
        {
                _logger = logger;
        }


        public async Task<JObject?> GetStockprice(Stockdata stockdata)
        {
            var apiKey = "EO4BB53HAZMW6TDW";
            string apiUrl = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={stockdata.Symbol}&apikey={apiKey}";

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
                        IntraStockprice stockPrice = globalQuote.ToObject<IntraStockprice>();
                        Console.WriteLine("Success");
                        Console.WriteLine(stockPrice.Symbol);
                        Console.WriteLine(stockPrice.Price);
                        return data;
                    }

                    else
                    {
                        Console.WriteLine("Fail");
                        _logger.LogInformation("Api call failed!");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new JObject();
                }
            }
        }


    }
}
