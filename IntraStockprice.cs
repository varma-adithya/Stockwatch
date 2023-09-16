﻿using Newtonsoft.Json;

namespace Stockwatch
{
    public class IntraStockprice
    {
        [JsonProperty("01. symbol")]
        public string Symbol { get; set; }

        [JsonProperty("02. open")]
        public decimal Open { get; set; }

        [JsonProperty("03. high")]
        public decimal High { get; set; }

        [JsonProperty("04. low")]
        public decimal Low { get; set; }

        [JsonProperty("05. price")]
        public decimal Price { get; set; }

        [JsonProperty("06. volume")]
        public long Volume { get; set; }

        [JsonProperty("07. latest trading day")]
        public DateTime LatestTradingDay { get; set; }

        [JsonProperty("08. previous close")]
        public decimal PreviousClose { get; set; }

        [JsonProperty("09. change")]
        public decimal Change { get; set; }

        [JsonProperty("10. change percent")]
        public string? Percentchange { get; set; }

    }
}
