using MarketDataDashboard.Service.Contracts;

namespace MarketDataDashboard.Service.Interfaces
{
    public interface IMarketSecurityPositionManager
    {
        SecuritiesCurrentMarketPositionsDto RetrieveCurrentMarketPosition();

    }
}
