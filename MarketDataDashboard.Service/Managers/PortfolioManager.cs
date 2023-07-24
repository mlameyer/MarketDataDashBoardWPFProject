using MarketDataDashboard.Service.Contracts;
using MarketDataDashboard.Service.Interfaces;
using MarketDataDashboard.Service.Repositiories.DBModels;
using MarketDataDashboard.Service.Repositiories.Interfaces;
using System.Collections.Generic;

namespace MarketDataDashboard.Service.Managers
{
    public class PortfolioManager : IPortfolioManager
    {
        private IPersistentStorageRepositiory _persistentStorageRepositiory;
        private IStockMarketRepositiory _stockMarketRepositiory;
        public PortfolioManager(IPersistentStorageRepositiory persistentStorageRepositiory, IStockMarketRepositiory stockMarketRepositiory)
        {
            _persistentStorageRepositiory = persistentStorageRepositiory;
            _stockMarketRepositiory = stockMarketRepositiory;
        }

        public PortfolioDto RetrievePortfolio()
        {
            PortfolioDto portfolioDto = new PortfolioDto();

            IEnumerable<SecurityDBContext> securityDBContexts = _persistentStorageRepositiory.ReadPortfolioFromDatabase();

            foreach (var securityDBContext in securityDBContexts)
            {
                portfolioDto.AddSecurityToPortfolio(
                    description: securityDBContext.Description,
                    tradeDate: securityDBContext.TradeDate,
                    action: securityDBContext.Action,
                    price: securityDBContext.Price,
                    quantity: securityDBContext.Quantity,
                    cost: securityDBContext.Cost
                    );

                portfolioDto.AddSecurityToPortfolioPandL(
                    cost: securityDBContext.Cost, 
                    description: securityDBContext.Description, 
                    quantity: securityDBContext.Quantity
                    );
            }

            IEnumerable<TradeDataContext> a = _stockMarketRepositiory.GetCurrentMarketPositionsForSecurities(portfolioDto.SecuritiesPandL.Keys);
            
            foreach (var tradeDataContext in a)
            {
                portfolioDto.SecuritiesPandL.TryGetValue(tradeDataContext.Symbol, out SecurityPandLDto securityPandLDto);
                securityPandLDto.CalculatePandLPosition(tradeDataContext.High, tradeDataContext.Close);
            }

            return portfolioDto.Equals(null) ? new PortfolioDto() : portfolioDto;
        }
    }
}
