using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using AutoLotDAL;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using static System.Console;

namespace AutoLotCUIClient
{
    class AutoLotCUIClientProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** The AutoLot Console UI *****\n");

            // Get connection string from App.config.
            string connectionString =
              ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";

            // Create our InventoryDAL object.
            InventoryDAL autoLotConnection = new InventoryDAL();
            autoLotConnection.OpenConnection(connectionString);

            // Keep asking for input until user presses the Q key.
            try
            {
                ShowInstructions();
                while (userDone != true)
                {
                    Write("\nPlease enter your command: ");
                    userCommand = ReadLine();
                    WriteLine();
                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewCar(autoLotConnection);
                            break;
                        case "R":
                            ProcessCreditRisk(autoLotConnection);
                            break;
                        case "X":
                            ListCreditRisks(autoLotConnection);
                            break;
                        case "U":
                            UpdateCarName(autoLotConnection);
                            break;
                        case "D":
                            DeleteCar(autoLotConnection);
                            break;
                        case "L":
                            // ListInventory(inventoryDAL);
                            ListInventoryViaList(autoLotConnection);
                            break;
                        case "C":
                            ListCustomers(autoLotConnection);
                            break;
                        case "O":
                            // ListInventory(inventoryDAL);
                            ListCustomersOrders(autoLotConnection);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "N":
                            LookUpName(autoLotConnection);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            WriteLine("Unknown Command.");
                            ShowInstructions();
                            break;
                    }
                };
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                ReadLine();
            }
            finally
            {
                autoLotConnection.CloseConnection();
            }
        }
        private static void ShowInstructions()
        {
            WriteLine("I: Inserts a new car.");
            WriteLine("U: Updates an existing car.");
            WriteLine("D: Deletes an existing car.");
            WriteLine("L: Lists current inventory.");
            WriteLine("O: Lists customers orders.");
            WriteLine("S: Shows these instructions.");
            WriteLine("C: Show all customers.");
            WriteLine("R: Process Credit Risk.");
            WriteLine("X: Lists Credit Risks.");
            WriteLine("N: Looks up car name.");
            WriteLine("Q: Quits program.");
        }

        /// <summary>
        /// List all cars in the inventory using datareader
        /// </summary>
        /// <param name="dataAccessLayer"></param>
		private static void ListInventoryViaList(InventoryDAL dataAccessLayer)
        {
            // Get the list of inventory via datareader
            List<Car> carList = dataAccessLayer.GetAllInventoryAsList();

            WriteLine("CarId\tMake\tColor\tName:");
            foreach (Car car in carList)
            {
                WriteLine($"{car.CarId}\t{car.Make}\t{car.Color}\t{car.Name}");
            }
        }

        /// <summary>
        /// List all customers in the database
        /// </summary>
        /// <param name="dataAccessLayer"></param>
        private static void ListCustomers(InventoryDAL dataAccessLayer)
        {
            List<Customer> customerList = dataAccessLayer.GetAllCustomersAsList();
            WriteLine("CustId\tName");

            foreach (Customer customer in customerList)
                WriteLine($"{customer.CustId}\t{customer.FirstName}\t{customer.LastName}");
        }

        /// <summary>
        /// List inventory using datatable
        /// </summary>
        /// <param name="dataAccessLayer"></param>
		private static void ListInventory(InventoryDAL dataAccessLayer)
        {
            // Get the list of inventory.
            DataTable inventoryDataTable = dataAccessLayer.GetAllInventoryAsDataTable();
            // Pass DataTable to helper function to display.
            DisplayTable(inventoryDataTable);
        }

        /// <summary>
        /// List customer orders via a datatable
        /// </summary>
        /// <param name="dataAccessLayer"></param>
        private static void ListCustomersOrders(InventoryDAL dataAccessLayer)
        {
            // Get the list of customers orders using a view
            DataTable customerOrdersDataTable = dataAccessLayer.GetDataTable("CustomerOrders");
            // Pass DataTable to helper function to display.
            DisplayTable(customerOrdersDataTable);
        }

        /// <summary>
        /// List credit risks via a datatable
        /// </summary>
        /// <param name="dataAccessLayer"></param>
        private static void ListCreditRisks(InventoryDAL dataAccessLayer)
        {
            // Get the list of credit risks using a view
            DataTable dataTable = dataAccessLayer.GetDataTable("CreditRisks");
            // Pass DataTable to helper function to display.
            DisplayTable(dataTable);
        }

        /// <summary>
        /// Display a datatable
        /// </summary>
        /// <param name="dataTable"></param>
        private static void DisplayTable(DataTable dataTable)
        {
            const int columnWidth = 10;

            // Print out the column names using collection

            foreach (DataColumn column in dataTable.Columns)
                Write($"{column.ColumnName,columnWidth}");
            WriteLine();

            // Print out the column names.
            //for (int column = 0; column < dataTable.Columns.Count; column++)
            //{
            //    // output the column name, note 2nd arg to string interpolation is width

            //    Write($"{dataTable.Columns[column].ColumnName,columnWidth}");
            //}
            //WriteLine();

            // write the correct number of dashes to cover the columns

            WriteLine(new string('-', columnWidth * dataTable.Columns.Count)); // 

            // Print the DataTable.

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (object column in row.ItemArray)
                    Write($"{column,columnWidth}");
                WriteLine();
            }

            // Print the DataTable.
            //for (int row = 0; row < dataTable.Rows.Count; row++)
            //{
            //    for (int column = 0; column < dataTable.Columns.Count; column++)
            //    {
            //        // output the row data, note 2nd arg to string interpolation is width
            //        Write($"{dataTable.Rows[row][column],columnWidth}");
            //    }
            //    WriteLine();
            //}
        }

        /// <summary>
        /// Prompt the user for a CarId, and then delete the car.
        /// </summary>
        /// <param name="inventoryDAL"></param>
		private static void DeleteCar(InventoryDAL inventoryDAL)
        {
            // Get ID of car to delete.
            Write("Enter ID of Car to delete: ");
            int carId = int.Parse(ReadLine() ?? "0");

            // Just in case we have a primary key violation!
            try
            {
                inventoryDAL.DeleteCar(carId);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Prompt the user for a new car to add and then insert in the database
        /// </summary>
        /// <param name="inventoryDAL"></param>
		private static void InsertNewCar(InventoryDAL inventoryDAL)
        {
            Write("Enter Car ID: ");
            var carId = int.Parse(ReadLine() ?? "0");
            Write("Enter Car Color: ");
            var carColor = ReadLine();
            Write("Enter Car Make: ");
            var carMake = ReadLine();
            Write("Enter Car Name: ");
            var carName = ReadLine();

            // Now pass to data access library.
            // inventoryDAL.InsertAuto(newCarId, newCarColor, newCarMake, newCarPetName);
            inventoryDAL.InsertAuto(new Car
            {
                CarId = carId,
                Color = carColor,
                Make = carMake,
                Name = carName
            });
        }

        /// <summary>
        /// Prompt the user for a CarId and Name, and update the record if found
        /// </summary>
        /// <param name="inventoryDAL"></param>

        private static void UpdateCarName(InventoryDAL inventoryDAL)
        {
            // First get the user data.
            Write("Enter Car ID: ");
            var carId = int.Parse(ReadLine() ?? "0");
            Write("Enter Car Name: ");
            var carName = ReadLine();

            // Now pass to data access library.
            inventoryDAL.UpdateCarName(carId, carName);
        }

        /// <summary>
        /// Prompt the user for a CarId, and do a lookup of the name
        /// </summary>
        /// <param name="inventoryDAL"></param>
		private static void LookUpName(InventoryDAL inventoryDAL)
        {
            // Get ID of car to look up.
            Write("Enter ID of Car to look up: ");
            int carId = int.Parse(ReadLine() ?? "0");
            WriteLine($"Car Name of CarId {carId} is {inventoryDAL.LookUpName(carId).TrimEnd()}.");
        }

        /// <summary>
        /// Process the credit risk by moving the customer from the customers 
        /// table to the credit risk table
        /// </summary>
        /// <param name="inventoryDAL"></param>
        private static void ProcessCreditRisk(InventoryDAL inventoryDAL)
        {
            // Get ID of car to delete.
            Write("Enter Customer ID who is now a credit risk: ");
            int customerId = int.Parse(ReadLine() ?? "0");

            // Just in case we have a primary key violation!
            try
            {
                inventoryDAL.ProcessCreditRisk(false, customerId);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

    }
}
