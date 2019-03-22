using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Console;

namespace SimpleDataProviderFactory
{
    /// <summary>
    /// Demonstrates connecting to either a local DB or via the server. 
    /// Note only one line needs to be changed to do this.
    /// The factory creates the connection object, and we hand the object the connection string
    ///     from App.config
    /// </summary>
	class SimpleDataProviderFactoryProgram
	{
		static void Main(string[] args)
		{
			WriteLine("***** Fun with Data Provider Factories *****\n");

            // Get Connection string/provider from *.config.
            string dataProvider =
                ConfigurationManager.AppSettings["provider"];

            string connectionString =
               ConfigurationManager.AppSettings["connectToAutoLot"];
            //string connectionString =
            //    ConfigurationManager.AppSettings["connectToLocalAutoLot"];

            // Get the factory provider.
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

			// Now get the connection object.
			using (DbConnection connection = factory.CreateConnection())
			{
				if (connection == null)
				{
					ShowError("Connection");
					return;
				}
				WriteLine($"Your connection object is a: {connection.GetType().Name}");
				connection.ConnectionString = connectionString;
				connection.Open();

				var sqlConnection = connection as SqlConnection;
				if (sqlConnection != null)
				{
					// Print out which version of SQL Server is used.
					WriteLine(sqlConnection.ServerVersion);
                    WriteLine(sqlConnection.Database);
				}

				// Make command object.
				DbCommand command = factory.CreateCommand();
				if (command == null)
				{
					ShowError("Command");
					return;
				}
				WriteLine($"Your command object is a: {command.GetType().Name} from {sqlConnection.Database}");

                command.Connection = connection;
                command.CommandText = $"Select * From [Customers]";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");

                    WriteLine("***** Current Customers *****");
                    WriteLine($"Fields = {dataReader.FieldCount}");
                    while (dataReader.Read())
                        WriteLine($"-> Customer #{dataReader["CustId"]} is {dataReader["FirstName"]} {dataReader["LastName"]}.");

                }

                command.Connection = connection;
                command.CommandText = $"Select * From [Inventory]";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");

                    WriteLine("***** Current Inventory *****");
                    WriteLine($"Fields = {dataReader.FieldCount}");
                    while (dataReader.Read())
                        WriteLine($"-> Car #{dataReader["CarId"]} is {dataReader["Make"]} {dataReader["Color"]} {dataReader["Name"]}.");
                }
            }
			ReadLine();
		}

		private static void ShowError(string objectName)
		{
			WriteLine($"There was an issue creating the {objectName}");
			ReadLine();
		}
	}
}
