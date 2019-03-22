using System;
using System.Configuration;
// Need these to get definitions of common interfaces,
// and various connection objects for our test.
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Console;

namespace SimpleConnection
{

	class SimpleConnectionProgram
	{
        static void Main(string[] args)
        {
            WriteLine("**** Very Simple Connection Factory *****\n");

            // Read the provider key.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            // use the goofy app setting just for fun
            // string dataProviderString = ConfigurationManager.AppSettings["Message"];

            // demonstrate the use of App.config settings
            WriteLine(ConfigurationManager.AppSettings["Message"]);

            // Get a specific connection.

            IDbConnection myConnection = GetConnection(dataProviderString);

            // Open, use and close connection...

            WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");

            ReadLine();
		}

        static IDbConnection GetConnection(string dataProvider)
        {
            switch(dataProvider)
            {
                case "SqlServer":
                    return (new SqlConnection()); // we will use this one a lot!!
                case "OleDb":
                    return (new OleDbConnection());
                case "Odbc":
                    return new OdbcConnection();
                default:
                    return null;
            }
        }
	}
}
