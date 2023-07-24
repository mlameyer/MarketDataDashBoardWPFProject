using MarketDataDashboard.Service.Contracts;

namespace MarketDataDashboard.Service.Interfaces
{
    public interface IPortfolioManager
    {
        PortfolioDto RetrievePortfolio();
    }
}
