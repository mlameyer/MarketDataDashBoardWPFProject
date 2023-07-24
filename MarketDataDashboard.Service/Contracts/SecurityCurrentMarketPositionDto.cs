using System;

namespace MarketDataDashboard.Service.Contracts
{
    public class SecurityCurrentMarketPositionDto
    {
        public string Security { get; set; }

        public DateTime TradeDate { get; set; }

        public string Action { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

    }
}
