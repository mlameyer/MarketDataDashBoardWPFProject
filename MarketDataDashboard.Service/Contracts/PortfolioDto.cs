using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace MarketDataDashboard.Service.Contracts
{
    public class PortfolioDto : ObservableCollection<PortfolioDto>
    {
        private readonly List<SecurityDto> _securitiesTransactionHistory;
        public IReadOnlyCollection<SecurityDto> SecuritiesTransactionHistory => _securitiesTransactionHistory;

        private readonly Dictionary<string, SecurityPandLDto> _securitiesPandL;

        public IReadOnlyDictionary<string, SecurityPandLDto> SecuritiesPandL => _securitiesPandL;

        public PortfolioDto() : base()
        {
            _securitiesTransactionHistory = new List<SecurityDto>();
            _securitiesPandL = new Dictionary<string, SecurityPandLDto>();
        }

        public void AddSecurityToPortfolio(string description, DateTime tradeDate, string action, decimal quantity,
            decimal price, decimal cost)
        {

            _securitiesTransactionHistory.Add(new SecurityDto(
                  description,
                  tradeDate,
                  action,
                  quantity,
                  price,
                  cost
                ));
        }

        public void AddSecurityToPortfolioPandL(decimal cost, string description, decimal quantity)
        {
            if(_securitiesPandL.ContainsKey(description))
            {
                 _securitiesPandL.TryGetValue(description, out SecurityPandLDto securityPandL);
                securityPandL.UpdateSecurityPandL(cost, quantity);
                _securitiesPandL.Remove(description);
                _securitiesPandL.Add(description, securityPandL);
            }
            else
            {
                _securitiesPandL.Add(description, new SecurityPandLDto(
                cost,
                description,
                quantity
                ));
            }
        }
    }

    public class SecurityDto
    {
        public string Description { get; }

        public DateTime TradeDate { get; }

        public string Action { get; }

        public decimal Quantity { get; }

        public decimal Price { get; }

        public decimal Cost { get; }

        public SecurityDto(string description, DateTime tradeDate, string action, decimal quantity,
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

    public class SecurityPandLDto
    {
        public string Description { get; }

        public DateTime AsOfDate { get; private set; }

        public decimal Cost { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal Price { get; private set; }

        public decimal MarketValue { get; private set; }

        public decimal PreviousClose { get; private set; }

        public decimal DailyPandL { get; private set; }

        public decimal InceptionPandL { get; private set; }

        public SecurityPandLDto(decimal cost, string description, decimal quantity)
        {
            Description = description;
            AsOfDate = DateTime.UtcNow;
            Cost = cost;
            Quantity = quantity; 
        }

        public void UpdateSecurityPandL(decimal cost, decimal quantity)
        {
            AsOfDate = DateTime.UtcNow;
            Cost += cost;
            Quantity += quantity;
        }

        public void CalculatePandLPosition(decimal currentPrice, decimal previosClose)
        {
            MarketValue = currentPrice * Quantity;
            DailyPandL = Quantity * (currentPrice - previosClose);
            InceptionPandL = MarketValue - Cost;
            Price = currentPrice;
            PreviousClose = previosClose;
        }
    }
}
