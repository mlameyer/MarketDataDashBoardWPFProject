using MarketDataDashboard.Service.Contracts;
using MarketDataDashboard.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarketDataDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMarketSecurityPositionManager _securityPositionManager;
        private IPortfolioManager _portfolioManager;

        private SecuritiesCurrentMarketPositionsDto securitiesDto;
        private PortfolioDto portfolioDto;

        public MainWindow(IMarketSecurityPositionManager securityPositionManager, IPortfolioManager portfolioManager)
        {
            _securityPositionManager = securityPositionManager;
            _portfolioManager = portfolioManager;
            InitializeComponent();

            securitiesDto = new SecuritiesCurrentMarketPositionsDto();
            currentMarketGrid.ItemsSource = securitiesDto;

            portfolioDto = new PortfolioDto();
            currentPortfolioGrid.ItemsSource = portfolioDto.SecuritiesTransactionHistory;
            currentPortfolioPandLGrid.ItemsSource = portfolioDto.SecuritiesPandL;
        }

        private void btnGetCurrentMarket_Click(object sender, RoutedEventArgs e)
        {
            currentMarketGrid.ItemsSource = _securityPositionManager.RetrieveCurrentMarketPosition();
            
        }

        private void btnGetPortfolio_Click(object sender, RoutedEventArgs e)
        {
            currentPortfolioGrid.ItemsSource = _portfolioManager.RetrievePortfolio().SecuritiesTransactionHistory;
            currentPortfolioPandLGrid.ItemsSource = _portfolioManager.RetrievePortfolio().SecuritiesPandL.Values;
        }
    }
}
