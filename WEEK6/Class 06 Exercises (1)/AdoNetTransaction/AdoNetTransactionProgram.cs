
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL;
using AutoLotDAL.ConnectedLayer;
using static System.Console;
using AutoLotDAL.Models;

namespace AdoNetTransaction
{
    class AdoNetTransactionProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** Simple Transaction Example *****\n");

            // A simple way to allow the tx to succeed or not.
            bool throwEx = true;

            Write("Do you want to throw an exception (Y or N): ");
            var userAnswer = ReadLine();
            if (userAnswer?.ToLower() == "n")
            {
                throwEx = false;
            }

            var dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;" + "Initial Catalog=AutoLot");

            // Process customer .
            dal.ProcessCreditRisk(throwEx, 1);
            WriteLine("Check CreditRisk table for results");
            ReadLine();
        }
    }
}
