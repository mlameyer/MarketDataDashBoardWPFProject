using MarketDataDashboard.Service.Repositiories.DBModels;
using MarketDataDashboard.Service.Repositiories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MarketDataDashboard.Service.Repositiories
{
    public class PersistentStorageRepositiory : IPersistentStorageRepositiory
    {
        public PersistentStorageRepositiory()
        {
            
        }

        public IEnumerable<SecurityDBContext> ReadPortfolioFromDatabase()
        {
            List<SecurityDBContext> list = new List<SecurityDBContext>();

            using (StreamReader file = new StreamReader("..\\PortfolioPersistentStorage.txt"))
            {
                while (!file.EndOfStream) 
                {
                    string[] line = file.ReadLine().Split('|');
                    list.Add(new SecurityDBContext(
                        description: line[0],
                        tradeDate: DateTime.Parse(line[1]),
                        action: line[2],
                        quantity: decimal.Parse(line[3]),
                        price: decimal.Parse(line[4]),
                        cost: decimal.Parse(line[5])
                        ));
                }
            }

            return list.Equals(null) ? new List<SecurityDBContext>() : list;
        }
    }
}
