using FDTraderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDTraderApp.Helpers
{
    public static class Helpers
    {
        public static Position GetPosition(Trade trade, List<Security> securities)
        {
            Position position = new Position()
            {
                Trade = trade,
                PositionValue = trade.Price * trade.Qty,
                PnL = (securities.Single(s => s.Name == trade.SecurityName).Price - trade.Price) * trade.Qty
            };

            return position;
        }

        public static Trade ParseTradeData(string tradeData, List<Security> securities)
        {
            string[] splitTradeData = tradeData.Split(' ');

            Trade trade = new Trade()
            {
                SecurityName = splitTradeData[0],
                Qty = int.Parse(splitTradeData[1]),
                Price = securities.Single(s => s.Name == splitTradeData[0]).Price
            };

            return trade;
        }

        public static List<Security> GetSecuritesData()
        {
            List<Security> securities = new List<Security>() {
                new Security { Name = "BARCLAYS", ISIN = "GB4246DS4BA9", When = new DateTime(2018, 08, 21, 18, 00, 00), Price = 184.40m },
                new Security { Name = "VODAFONE_GRP", ISIN = "GB5A6F8T44V3", When = new DateTime(2018, 08, 21, 18, 00, 00), Price = 176.14m },
                new Security { Name = "GLENCORE", ISIN = "GB64DH3SDF47", When = new DateTime(2018, 08, 21, 18, 00, 00), Price = 306.80m }
            };

            return securities;
        }

        public static List<Security> GetNewSecuritesData()
        {
            List<Security> securities = new List<Security>() {
                new Security { Name = "BARCLAYS", ISIN = "GB4246DS4BA9", When = new DateTime(2018, 08, 22, 18, 00, 00), Price = 189.43m },
                new Security { Name = "VODAFONE_GRP", ISIN = "GB5A6F8T44V3", When = new DateTime(2018, 08, 22, 18, 00, 00), Price = 146.24m },
                new Security { Name = "GLENCORE", ISIN = "GB64DH3SDF47", When = new DateTime(2018, 08, 22, 18, 00, 00), Price = 321.45m }
            };

            return securities;
        }
    }
}