using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDTraderApp.Models
{
    public class Trade
    {
        public string SecurityName { get; set; }

        public decimal Qty { get; set; }

        public decimal Price { get; set; }
    }
}