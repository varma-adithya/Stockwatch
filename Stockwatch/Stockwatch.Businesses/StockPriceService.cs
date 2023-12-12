using Microsoft.Extensions.Logging;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;
        public StockPriceService(IHttpClientFactory httpClientFactory, ILogger<StockPriceService> logger)
        {
          _logger = logger;   
          _httpClientFactory = httpClientFactory;
        }

        public async Task<IntraStockPrice> GetStockPrice(AlphaVantageAPI urlOptions)
        {
            string url = string.Format(urlOptions.ApiUrl, urlOptions.SymbolName, urlOptions.ApiKey);
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        if (jsonContent != null)
                        {
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
                            _logger.LogInformation("API response is Null");
                            return null;
                    }
                    else
                    {
                        _logger.LogInformation("API request has failed");
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Error: {ex}");
                    throw;
                }
            }
        }


    }
}
