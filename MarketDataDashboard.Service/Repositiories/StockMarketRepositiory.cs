using MarketDataDashboard.Service.Repositiories.DBModels;
using MarketDataDashboard.Service.Repositiories.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace MarketDataDashboard.Service.Repositiories
{
    public class StockMarketRepositiory : IStockMarketRepositiory
    {
        public StockMarketRepositiory()
        {
            
        }

        public IEnumerable<TradeDataContext> GetCurrentMarketPositionsForSecurities(IEnumerable<string> securities)
        {
            List<TradeDataContext> tradeDataContexts = new List<TradeDataContext>();
            MetaData metaData = new MetaData();
            TimeSeries timeSeries = new TimeSeries();
            foreach (string security in securities)
            {
                string QUERY_URL = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={security}&apikey=J28MUJZ0FXSQC7NA";
                Uri queryUri = new Uri(QUERY_URL);

                using (WebClient client = new WebClient())
                {
                    string result = client.DownloadString(queryUri);
                    metaData = JsonConvert.DeserializeObject<MetaData>(result);
                    timeSeries = JsonConvert.DeserializeObject<TimeSeries>(result);
                }

                DateTime currentDay = timeSeries.attributes.Keys.Max(a => a.Date);
                timeSeries.attributes.TryGetValue(currentDay, out TimeSeriesAttribute timeSeriesAttribute);

                tradeDataContexts.Add(
                    new TradeDataContext(
                        symbol: metaData.metaData.symbol,
                        tradeDate: currentDay,
                        open: timeSeriesAttribute.open,
                        high: timeSeriesAttribute.high,
                        low: timeSeriesAttribute.low,
                        close: timeSeriesAttribute.close,
                        volume: timeSeriesAttribute.volume
                        ));
            }

            return tradeDataContexts.Equals(null) ? new List<TradeDataContext>() : tradeDataContexts;
        }


    }

    internal class MetaData
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public MetaDataAttributes metaData { get; set; }
    }

    internal class MetaDataAttributes
    {
        [JsonProperty(PropertyName = "1. Information")]
        public string Information { get; set; }

        [JsonProperty(PropertyName = "2. Symbol")]
        public string symbol { get; set; }

        [JsonProperty(PropertyName = "3. Last Refreshed")]
        public string lastRefreshed { get; set; }

        [JsonProperty(PropertyName = "4. Output Size")]
        public string outputSize { get; set; }

        [JsonProperty(PropertyName = "5. Time Zone")]
        public string timezone { get; set; }
    }

    internal class TimeSeries
    {
        [JsonProperty(PropertyName = "Time Series (Daily)")]
        public Dictionary<DateTime, TimeSeriesAttribute> attributes { get; set; }
    }

    internal class TimeSeriesAttribute
    {
        [JsonProperty(PropertyName = "1. open")]
        public decimal open { get; set; }

        [JsonProperty(PropertyName = "2. high")]
        public decimal high { get; set; }

        [JsonProperty(PropertyName = "3. low")]
        public decimal low { get; set; }

        [JsonProperty(PropertyName = "4. close")]
        public decimal close { get; set; }

        [JsonProperty(PropertyName = "5. volume")]
        public decimal volume { get; set; }
    }
}
