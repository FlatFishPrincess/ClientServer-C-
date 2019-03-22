using System;
using System.Data.SqlClient;
using static System.Console;

namespace AutoLotDataReader
{
	class AutoLotDataReaderProgram
	{

        static void Main(string[] args)
        {
            SimpleSQLCommand();
            MultipleSQLCommands();

        }

        static void SimpleSQLCommand()
		{
			WriteLine("***** Fun with Data Readers V1 *****\n");
			// Create and open a connection.
			using (SqlConnection connection = new SqlConnection())
			{
                // build the connection string by hand

				connection.ConnectionString =
                    @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;" +
					"Initial Catalog=AutoLot";
				connection.Open();

                WriteLine("++++ INVENTORY ++++");

                // Create a SQL command object.
                string sql = "Select * From Inventory";
				SqlCommand myCommand = new SqlCommand(sql, connection);

				// Obtain a data reader a la ExecuteReader().
				using (SqlDataReader myDataReader = myCommand.ExecuteReader())
				{
					// Loop over the results.
					while (myDataReader.Read())
					{
						WriteLine($"-> Make: {myDataReader["Make"]}, Name: {myDataReader["Name"]}, Color: {myDataReader["Color"]}.");
					}
				}

                ShowConnectionStatus(connection);
            }

            ReadLine();
		}

        static void MultipleSQLCommands()
        {
            WriteLine("***** Fun with Data Readers V2 *****\n");
            // Create a connection string via the builder object.
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "AutoLot",
                DataSource = @"(localdb)\MSSQLLocalDB",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };

            // Create an open a connection.
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = connectionStringBuilder.ConnectionString;
                connection.Open();
                ShowConnectionStatus(connection);

                // Create a SQL command object. Note two select statements

                string sql = "Select * From Inventory;Select * from Customers";

                WriteLine("++++ INVENTORY and CUSTOMERS ++++");

                using (SqlCommand myCommand = new SqlCommand(sql, connection))
                {
                    //iterate over the inventory & customers
                    // Obtain a data reader a la ExecuteReader().

                    // note use of getname and getvalue for each field

                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {
                        do
                        {
                            while (myDataReader.Read())
                            {
                                WriteLine("***** Record *****");
                                for (int i = 0; i < myDataReader.FieldCount; i++)
                                {
                                    WriteLine($"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}");
                                }
                                WriteLine();
                            }
                        } while (myDataReader.NextResult());
                    }

                    ShowConnectionStatus(connection);

                }
            }

            ReadLine();
        }
		static void ShowConnectionStatus(SqlConnection connection)
		{
			// Show various stats about current connection object.
			WriteLine("***** Info about your connection *****");
			WriteLine($"Database location: {connection.DataSource}");
			WriteLine($"Database name: {connection.Database}");
			WriteLine($"Timeout: {connection.ConnectionTimeout}");
			WriteLine($"Connection state: {connection.State}\n");
		}

	}
}
