using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoLotDAL.Models;

namespace AutoLotDAL.ConnectedLayer
{

    /// <summary>
    /// Inventory Data Access Layer class
    /// Contains methods to access the Car Inventory database (usually AutoLot)
    /// But can also access other tables as needed.
    /// </summary>
    public class InventoryDAL
    {
        // This field will be used by all methods, holds the open connection
        private SqlConnection sqlConnection = null;

        /// <summary>
        /// Open a connection to the sql database
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        public void OpenConnection(string connectionString)
        {
            sqlConnection = new SqlConnection { ConnectionString = connectionString };
            sqlConnection.Open();
        }

        /// <summary>
        /// Close the sql database connection
        /// </summary>
        public void CloseConnection()
        {
            sqlConnection.Close();
        }

        /// <summary>
        /// Insert a car into the database
        /// </summary>
        /// <param name="car"></param>
        public void InsertAuto(Car car)
        {
            // Format and execute SQL statement.
            SetIdentityValue("Inventory", true);
            string sql = "Insert Into Inventory (CarId, Make, Color, Name) Values" +
                $"('{car.CarId}','{car.Make}', '{car.Color}', '{car.Name}')";

            // Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failure: " + sql, ex);
                    throw error;
                }
            }

            SetIdentityValue("Inventory", false);
        }

        /// <summary>
        /// Set identity on or off for a table.
        /// Allows us to insert Ids into a table when identity is preset
        /// </summary>
        /// <param name="table">Table have identity changed</param>
        /// <param name="value">true for ON, false for OFF</param>
        public void SetIdentityValue(string table, bool value)
        {
            if (table == null)
                return;
            string sql = "SET IDENTITY_INSERT [dbo].[" + table + "]" + (value == true? "ON":"OFF");

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Failure: " + sql, ex);
                    throw error;
                }

            }

        }

        /// <summary>
        /// Insert a car into the database using string arguments
        /// </summary>
        /// <param name="carColor">Color</param>
        /// <param name="carMake">Make</param>
        /// <param name="carName">Name of the car</param>
        public void InsertAuto(string carColor, string carMake, string carName)
        {
            // Note the "placeholders" in the SQL query.
            string sql = "Insert Into Inventory" +
                            "(Make, Color, Name) Values" +
                            "(@Make, @Color, @Name)";

            // This command will have internal parameters.
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                // Fill params collection.
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = carMake,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = carColor,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = carName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                });

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete a car by its Id
        /// </summary>
        /// <param name="id">Car Id</param>

        public void DeleteCar(int id)
        {
            // Get ID of car to delete, then do so.
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        /// <summary>
        /// Change the car name
        /// </summary>
        /// <param name="id">CarId</param>
        /// <param name="newName">New name of the car</param>
        public void UpdateCarName(int id, string newName)
        {
            // Get ID of car to modify and new pet name.
            string sql = $"Update Inventory Set Name = '{newName}' Where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get a list of cars in inventory
        /// </summary>
        /// <returns>A list of cars</returns>
        public List<Car> GetAllInventoryAsList()
        {
            // This will hold the records.
            List<Car> inv = new List<Car>();

            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    inv.Add(new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        Name = (string)dataReader["Name"]
                    });
                }
                dataReader.Close();
            }
            return inv;
        }

        /// <summary>
        /// Get a list of customers
        /// </summary>
        /// <returns>customer list</returns>
        public List<Customer> GetAllCustomersAsList()
        {
            // This will hold the records.
            List<Customer> customer = new List<Customer>();

            // Prep command object.
            string sql = "Select * From Customers";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    customer.Add(new Customer
                    {
                        CustId = (int)dataReader["CustId"],
                        FirstName = (string)dataReader["FirstName"],
                        LastName = (string)dataReader["LastName"],
                    });
                }
                dataReader.Close();
            }
            return customer;
        }

        /// <summary>
        /// Simple method to get a datatable from any sql table
        /// </summary>
        /// <param name="tableName">Name of the sql table</param>
        /// <returns>DataTable containing the sql data</returns>
        public DataTable GetDataTable(string tableName)
        {
            DataTable dataTable = new DataTable();

            string sql = "Select * From " + tableName;
            using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                // Fill the DataTable with data from the reader and clean up.
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;

        }

        /// <summary>
        /// Get the Inventory DataTable.
        /// This will be useful with DataGridView
        /// </summary>
        /// <returns>Inventory DataTable</returns>
        public DataTable GetAllInventoryAsDataTable()
        {
            // This will hold the records.
            DataTable dataTable = new DataTable();

            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                // Fill the DataTable with data from the reader and clean up.
                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// Get the CustomerOrders as a DataTable
        /// </summary>
        /// <returns>customer orders table</returns>
        public DataTable GetAllCustomersOrdersAsDataTable()
        {
            // This will hold the records.
            DataTable dataTable = new DataTable();

            // Prep command object.
            string sqlString = "Select * From [CustomerOrders]";
            using (SqlCommand command = new SqlCommand(sqlString, sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();
                // Fill the DataTable with data from the reader and clean up.
                dataTable.Load(dataReader);
                dataReader.Close();
            }

            return dataTable;
        }

        /// <summary>
        /// Get the car name associated with a CarId.
        /// Demonstrates use of stored procedure and parameters
        /// </summary>
        /// <param name="carId">CarId</param>
        /// <returns>The name of the car</returns>
        public string LookUpName(int carId)
        {
            string carName;

            // Establish name of stored proc.
            using (SqlCommand command = new SqlCommand("GetName", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Input param.
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input
                });

                // Output param.
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                });

                // Execute the stored proc.
                command.ExecuteNonQuery();

                // Return output param.
                carName = (string)command.Parameters["@name"].Value;
            }
            return carName;
        }

        /// <summary>
        /// Identify a customer as a credit risk, and move them
        /// to the CreditRisks table
        /// </summary>
        /// <param name="throwEx"></param>
        /// <param name="custId"></param>
        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            // First, look up current name based on customer ID.
            string firstName;
            string lastName;
            var commandSelect =
                new SqlCommand($"Select * from Customers where CustId = {custId}",
                                sqlConnection);
            using (var dataReader = commandSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    firstName = (string)dataReader["FirstName"];
                    lastName = (string)dataReader["LastName"];
                }
                else
                {
                    return;
                }
            }

            // Create command objects that represent each step of the operation.
            var commandRemove =
                new SqlCommand($"Delete from Customers where CustId = {custId}",
                sqlConnection);

            var commandInsert =
                new SqlCommand("Insert Into CreditRisks" +
                $"(FirstName, LastName) Values('{firstName}', '{lastName}')",
                sqlConnection);

            // We will get this from the connection object.
            SqlTransaction transaction = null;
            try
            {
                transaction = sqlConnection.BeginTransaction();

                // Enlist the commands into this transaction.
                commandInsert.Transaction = transaction;
                commandRemove.Transaction = transaction;

                // Execute the commands.
                commandInsert.ExecuteNonQuery();
                commandRemove.ExecuteNonQuery();

                // Simulate error.
                if (throwEx)
                {
                    throw new Exception("Sorry!  Database error! Transaction failed...");
                }

                // Commit it!
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Any error will roll back transaction.  Using the new conditional access operator to check for null.
                transaction?.Rollback();
            }
        }
    }
}
