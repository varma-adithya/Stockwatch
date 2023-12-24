using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stockwatch.Model;
using Stockwatch.Model.Dto;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stockwatch.Business
{
    public interface IStockPriceService
    {
        public Task<IntraStockPrice?> GetStockPriceAsync(StockSymbol Symbol);
    }

    public class StockPriceService : IStockPriceService
    {
        private readonly ApiOptions _urlOptions;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public StockPriceService(IOptions<ApiOptions> urlOptions, HttpClient httpClient, ILogger<StockPriceService> logger)
        {
            _urlOptions = urlOptions.Value;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IntraStockPrice?> GetStockPriceAsync(StockSymbol symbol)
        {
            if (symbol == null) 
                throw new ArgumentNullException(nameof(symbol));

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(string.Format(_urlOptions.ApiUrl, symbol.SymbolName, _urlOptions.ApiKey));
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
                        return JsonSerializer.Deserialize<IntraStockPrice>(jsonContent, serializeOptions);
                    }
                    else
                        _logger.LogWarning("API response is Null");
                }
                else
                {
                    var error = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                    _logger.LogError($"API request has failed: {error}");
                    throw new AlphaVantageException(error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failure in GetStockPriceAsync");
                throw;
            }

            return default;

        }
    }
}
