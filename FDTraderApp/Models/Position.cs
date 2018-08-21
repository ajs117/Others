using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDTraderApp.Models
{
    public class Position
    {
        public Trade Trade { get; set; }

        public decimal PositionValue { get; set; }

        public decimal PnL { get; set; }

        public void Print()
        {
            Console.WriteLine(Trade.SecurityName + " " + Trade.Qty + " " + PositionValue + " " + PnL);
        }
    }
}