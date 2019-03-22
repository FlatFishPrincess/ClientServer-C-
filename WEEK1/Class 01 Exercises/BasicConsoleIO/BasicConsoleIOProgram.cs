using System;
using System.Diagnostics;  // so we can use Debug to write to output
using System.Windows.Forms;  // so we can use MessageBox
using static System.Console; // notice use of this, so we don't have to write System.Console.WriteLine over and over

namespace BasicConsoleIO
{
    class BasicConsoleIOProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** Basic Console I/O *****");
            WriteLine("Program starting");

            GetUserData();  // get the input from the user and display
            ReadLine();

            MessageBox.Show("Waiting for input, look at output window");
            FormatNumericalData();
            ReadLine();

            WriteLine("Program ending");
        }

        /// <summary>
        /// Get user's name and age, then display on console
        /// </summary>
        private static void GetUserData()
        {
            WriteLine("Entering GetUserData()");
            // Get name and age.
            Write("Please enter your name: ");
            string userName = ReadLine();
            Write("Please enter your age: ");
            string userAge = ReadLine();

            // Change output color to yellow, just for fun.

            ConsoleColor previousColor = ForegroundColor; // save the original color
            ForegroundColor = ConsoleColor.Yellow;  // now set Console to yellow

            // Write to the console.
            WriteLine("Hello {0}! You are {1} years old.",
                userName, userAge);

            // Display something in the output window

            WriteLine("After output, name is {0}, age is {1}", userAge, userName);


            // Restore previous color.
            ForegroundColor = previousColor;

        }

        /// <summary>
        /// Display a value using various string formats
        /// </summary>
        static void FormatNumericalData()
        {
            double percent = 0.25346;
            const int displayValue = 99999;
            WriteLine("{0} {1} {2}", "The value ", displayValue, " in various formats");
            WriteLine("10:c format: {0,10:c}", displayValue);
            WriteLine(" 20:d9 format right justified: *{0,20:d9}*", displayValue);
            WriteLine("-20:d9 format left justified: *{0,-20:d9}*", displayValue);

            WriteLine("f3 format: {0:f3}", displayValue);
            WriteLine("n4 format: {0:n4}", displayValue);
            // Notice that upper- or lowercasing for hex
            // determines if letters are upper- or lowercase.
            WriteLine("E format: {0:E}", displayValue);
            WriteLine("e format: {0:e}", displayValue);
            WriteLine("X format: {0:X}", displayValue);
            WriteLine("x format: {0:x}", displayValue);

            WriteLine($"Display .25346 ({percent:P3}) in various formats:");
            WriteLine("P percent format: {0:p}", percent);
            WriteLine("P5 percent format: {0:P5}", percent);
            WriteLine("P5 percent format ToString(\"P5\"): " + percent.ToString("P5"));
        }
    }
}
