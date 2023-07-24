using MarketDataDashboard.Service.Contracts;
using MarketDataDashboard.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace MarketDataDashboard.Service.Managers
{
    public class MarketSecurityPositionManager : IMarketSecurityPositionManager
    {
        public SecuritiesCurrentMarketPositionsDto RetrieveCurrentMarketPosition()
        {
            SecuritiesCurrentMarketPositionsDto securitiesCurrentMarketPositionsDto = new SecuritiesCurrentMarketPositionsDto();

            for (int i = 0; i < 10; i++)
            {
                securitiesCurrentMarketPositionsDto.Add(new SecurityCurrentMarketPositionDto()
                {
                    Security = "GOOGLE",
                    Action = "Buy",
                    TradeDate = DateTime.UtcNow,
                    Cost = 10L,
                    Price = 20L,
                    Quantity = 5L,
                });
            }

            return securitiesCurrentMarketPositionsDto;
        }
    }
}
