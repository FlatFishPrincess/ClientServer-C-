using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SalesOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Sales Order";

            // stringbuilder to store all items 
            StringBuilder itemName = new StringBuilder("", 200);
            double itemSubTotal = 0;
            double TAX_RATE = 0.12; 
            Write("Enter Command (i,p,q)");
            string command = ReadLine();
            while (command != "q")
            {
                Write("Enter item name: ");
                // itemNAme
            }
        }
    }
}
