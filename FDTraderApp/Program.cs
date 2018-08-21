using FDTraderApp.Helpers;
using FDTraderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FDTraderApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Security> securities = Helpers.Helpers.GetSecuritesData();

            foreach (var security in securities)
            {
                security.Print();
            }

            Console.WriteLine("Please type in your trade (Name followed by a space followed by Qty)");

            string tradeData = Console.ReadLine();

            Trade trade = Helpers.Helpers.ParseTradeData(tradeData, securities);

            Position position = Helpers.Helpers.GetPosition(trade, securities);

            position.Print();

            List<Security> newSecurities = Helpers.Helpers.GetNewSecuritesData();

            Position newPosition = Helpers.Helpers.GetPosition(trade, newSecurities);

            Thread.Sleep(3000);

            newPosition.Print();
        }
    }
}