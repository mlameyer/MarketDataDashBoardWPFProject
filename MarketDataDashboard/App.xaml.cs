﻿using MarketDataDashboard.Service.Interfaces;
using MarketDataDashboard.Service.Managers;
using MarketDataDashboard.Service.Repositiories;
using MarketDataDashboard.Service.Repositiories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MarketDataDashboard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IMarketSecurityPositionManager, MarketSecurityPositionManager>();
            services.AddTransient<IPortfolioManager, PortfolioManager>();
            services.AddTransient<IPersistentStorageRepositiory, PersistentStorageRepositiory>();
            services.AddTransient<IStockMarketRepositiory, StockMarketRepositiory>();

            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
