using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Console;

namespace DataFactoryProvider
{
    class DataProviderFactoryProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with Data Provider Factories *****\n");

            // Get Connection string/provider from *.config.
            string dataProvider =
                ConfigurationManager.AppSettings["provider"];
            //string connectionString =
            //	ConfigurationManager.AppSettings["connectionString"];
            string connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            //string connectionString =
            //	ConfigurationManager.ConnectionStrings["AutoLotOleDbProvider"].ConnectionString;

            // Get the factory provider.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            // Now get the connection object.
            DbConnection connection = factory.CreateConnection();

            if (connection == null)
            {
                ShowError("Connection");
                return;
            }
            WriteLine($"Your connection object is a: {connection.GetType().Name}");
            connection.ConnectionString = connectionString;
            connection.Open();

            // note use of pattern matching here!
            //   instead of a cast and a null test

            if (connection is SqlConnection sqlConnection)
            {
                // Print out which version of SQL Server is used.
                WriteLine(sqlConnection.ServerVersion);
            }

            // Make command object.
            DbCommand command = factory.CreateCommand();
            if (command == null)
            {
                ShowError("Command");
                return;
            }
            WriteLine($"Your command object is a: {command.GetType().Name}");
            command.Connection = connection;
            command.CommandText = "Select * From Inventory";

            // Print out data with data reader.
            DbDataReader inventoryReader = command.ExecuteReader(); // opens the connection and executes the command
            
            WriteLine($"Your inventory reader object is a: {inventoryReader.GetType().Name}");

            WriteLine("\n***** Current Inventory *****");
            while (inventoryReader.Read())
                WriteLine($"-> Car #{inventoryReader["CarId"]} is a {inventoryReader["Make"]} {inventoryReader["Name"]}.");

            inventoryReader.Close();  // can only have one open at a time

            command.Connection = connection;
            command.CommandText = "Select * From Customers";

            DbDataReader customerReader = command.ExecuteReader();
            
            WriteLine($"Your customer reader object is a: {customerReader.GetType().Name}");

            WriteLine("\n***** Current Customers *****");
            while (customerReader.Read())
                WriteLine($"-> Customer #{customerReader["CustID"]} is {customerReader["FirstName"]} {customerReader["LastName"]}.");

            customerReader.Close();
            connection.Close();
                
            ReadLine();
    
        }

		private static void ShowError(string objectName)
		{
			WriteLine($"There was an issue creating the {objectName}");
			ReadLine();
		}
	}
}
