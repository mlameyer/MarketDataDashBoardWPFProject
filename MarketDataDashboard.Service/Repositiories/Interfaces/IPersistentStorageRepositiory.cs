using MarketDataDashboard.Service.Repositiories.DBModels;
using System.Collections.Generic;

namespace MarketDataDashboard.Service.Repositiories.Interfaces
{
    public interface IPersistentStorageRepositiory
    {
        IEnumerable<SecurityDBContext> ReadPortfolioFromDatabase();
    }
}
