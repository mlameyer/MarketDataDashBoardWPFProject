using MarketDataDashboard.Service.Contracts;
using MarketDataDashboard.Service.Interfaces;
using System.Windows;

namespace MarketDataDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPortfolioManager _portfolioManager;

        private PortfolioDto portfolioDto;

        public MainWindow(IPortfolioManager portfolioManager)
        {
            _portfolioManager = portfolioManager;
            InitializeComponent();

            portfolioDto = new PortfolioDto();
            currentMarketGrid.ItemsSource = portfolioDto.SecuritiesCurrentPosition;
            currentPortfolioGrid.ItemsSource = portfolioDto.SecuritiesTransactionHistory;
            currentPortfolioPandLGrid.ItemsSource = portfolioDto.SecuritiesPandL;
        }

        private void btnGetPortfolio_Click(object sender, RoutedEventArgs e)
        {
            var results = _portfolioManager.RetrievePortfolio();
            currentMarketGrid.ItemsSource = results.SecuritiesCurrentPosition;
            currentPortfolioGrid.ItemsSource = results.SecuritiesTransactionHistory;
            currentPortfolioPandLGrid.ItemsSource = results.SecuritiesPandL.Values;
        }
    }
}
