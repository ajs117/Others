using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDTraderApp.Models
{
    public class Security
    {
        public string Name { get; set; }

        public string ISIN { get; set; }

        public DateTime When { get; set; }

        public decimal Price { get; set; }

        public void Print()
        {
            Console.WriteLine(Name + " " + ISIN + " " + When + " " + Price);
        }
    }
}