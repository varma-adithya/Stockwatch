using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockwatch
{
    public class Stockpriceservices
    {
        public IntraStockprice intraStockprice { get; set; }


        public async Task<IntraStockprice> GetStockprice(Stockdata stockdata)
        {
            string apiUrl = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={stockdata.Symbol}&apikey={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string jsonContent = await response.Content.ReadAsStringAsync();
                Stockdata currentData = ParseStockData(jsonContent);
                return currentData;
            }
            return null;
        }

        private Stockdata ParseStockData(string jsonContent)
        {

        }
    }
}
