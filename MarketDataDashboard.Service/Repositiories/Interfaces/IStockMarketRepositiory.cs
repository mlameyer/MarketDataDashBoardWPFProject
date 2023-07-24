using MarketDataDashboard.Service.Repositiories.DBModels;
using System.Collections.Generic;

namespace MarketDataDashboard.Service.Repositiories.Interfaces
{
    public interface IStockMarketRepositiory
    {
        IEnumerable<TradeDataContext> GetCurrentMarketPositionsForSecurities(IEnumerable<string> securities);
    }
}
