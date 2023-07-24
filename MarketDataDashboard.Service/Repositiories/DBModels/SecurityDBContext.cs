using System;

namespace MarketDataDashboard.Service.Repositiories.DBModels
{
    public class SecurityDBContext
    {
        public string Description { get; }

        public DateTime TradeDate { get; }

        public string Action { get; }

        public decimal Quantity { get; }

        public decimal Price { get; }

        public decimal Cost { get; }

        public SecurityDBContext(string description, DateTime tradeDate, string action, decimal quantity,
            decimal price, decimal cost)
        {
            Description = description;
            TradeDate = tradeDate;
            Action = action;
            Quantity = quantity;
            Price = price;
            Cost = cost;
        }
    }
}
