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
