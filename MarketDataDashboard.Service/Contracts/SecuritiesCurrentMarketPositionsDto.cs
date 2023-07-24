using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MarketDataDashboard.Service.Contracts
{
    public class SecuritiesCurrentMarketPositionsDto : ObservableCollection<SecurityCurrentMarketPositionDto>
    {
        public SecuritiesCurrentMarketPositionsDto() : base() {}
    }
}
