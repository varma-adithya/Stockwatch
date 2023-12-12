﻿using Microsoft.Extensions.Logging;
using Stockwatch.Model;
using Stockwatch.Model.Dto;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stockwatch.Business
{
    public interface IStockPriceService 
    {
        public Task<IntraStockPrice> GetStockPriceAsync(ApiOptions urlOptions, StockSymbol Symbol);
    }

    public class StockPriceService: IStockPriceService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public StockPriceService(HttpClient httpClient, ILogger<StockPriceService> logger)
        {
          _logger = logger;   
          _httpClient = httpClient;
        }

        public async Task<IntraStockPrice> GetStockPriceAsync(ApiOptions urlOptions, StockSymbol Symbol)
        {
            string url = string.Format(urlOptions.ApiUrl, Symbol.SymbolName, urlOptions.ApiKey);
            try
            {
                    HttpResponseMessage response = await _httpClient.GetAsync(url);
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
                        return default;
                    }
                    else
                    {
                        _logger.LogInformation("API request has failed");
                        var error = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                        throw new HttpRequestException(error);
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
