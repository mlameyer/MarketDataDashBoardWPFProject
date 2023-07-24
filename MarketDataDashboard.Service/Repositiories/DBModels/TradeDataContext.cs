using System;

namespace MarketDataDashboard.Service.Repositiories.DBModels
{
    public class TradeDataContext
    {
        public string Symbol { get; }

        public DateTime TradeDate { get; }

        public decimal Open { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public decimal Close { get; }

        public decimal Volume { get; }

        public TradeDataContext(string symbol, DateTime tradeDate, decimal open, decimal high, decimal low,
            decimal close, decimal volume)
        {
            Symbol = symbol;
            TradeDate = tradeDate;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }
    }
}
