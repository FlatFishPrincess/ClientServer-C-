using System;
using static System.Console;

namespace IterationsAndDecisions
{
    class IterationsAndDecisionsProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** Loops and Choices *****\n");
            ForAndForEachLoop();
            ReadLine();

            VarInForeachLoop();
            ReadLine();

            ExecuteWhileLoop();
            ReadLine();

            ExecuteDoWhileLoop();
            ReadLine();

            ExecuteIfElse();
            ReadLine();

            ExecuteSwitch();
            ReadLine();

            ExecuteSwitchOnString();
            ReadLine();

            SwitchOnEnumExample();
            ReadLine();
        }

        #region For / foreach loops

        /// <summary>
        /// Demonstrates basic loops
        /// </summary>
        static void ForAndForEachLoop()
        {
            WriteLine("For loops");
            // Note! "i" is only visible within the scope of the for loop.
            for (int i = 0; i < 4; i++)
            {
                WriteLine("Number is: {0} ", i);
            }
            // "i" is not visible here.
            WriteLine();

            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string car in carTypes)
            {
                WriteLine(car);
            }

            WriteLine();

            int[] myIntegers = { 10, 20, 30, 40 };
            foreach (int i in myIntegers)
            {
                WriteLine(i);
            }

            WriteLine();
        }
        #endregion

        #region Var keyword in foreach
        /// <summary>
        /// shows how var can be used in foreach loops through a collection
        /// </summary>
        static void VarInForeachLoop()
        {
            WriteLine("Var in foreach loop");

            int[] myIntegers = { 10, 20, 30, 40 }; // arrays are collections

            // Use "var" in a standard foreach loop.
            foreach (var item in myIntegers)
            {
                WriteLine("Item value: {0}", item);
            }

            WriteLine();
        }
        #endregion

        #region while loop
        /// <summary>
        /// shows basic while loop
        /// This can be used for the lab, pay attention here!
        /// Notice test at the top.
        /// </summary>
        static void ExecuteWhileLoop()
        {
            WriteLine("User input from while loop");
            string userIsDone = "no";

            // Test on a lower-class copy of the string.
            while (userIsDone.ToLower() != "yes")
            {
                Write("Are you done? [yes] [no]: ");
                userIsDone = ReadLine();
                WriteLine("In while loop");
            }
            WriteLine();
        }
        #endregion

        #region do/while loop
        /// <summary>
        /// Shows basic do...while loop. Generally, this is bad practice.
        /// 
        /// </summary>
        static void ExecuteDoWhileLoop()
        {
            WriteLine("User input from do..while loop");
            string userIsDone = "no"; // could be blank

            do
            {
                WriteLine("In do/while loop");
                Write("Are you done? [yes] [no]: ");
                userIsDone = ReadLine();
            } while (userIsDone.ToLower() != "yes"); // Note the semicolon!

            WriteLine();
        }
        #endregion

        #region If/else
        /// <summary>
        /// Shows basic if...then...else
        /// </summary>
        static void ExecuteIfElse()
        {
            WriteLine("If Else statements");

            string stringData = "My textual data";
            int max = 20;
            if (stringData.Length > 0 && stringData.Length < max)
            {
                WriteLine($"'{stringData}' is greater than 0 characters and less than {max}");
            }
            else
            {
                WriteLine($"'{stringData}' is <= 0 characters and >= {max}");
            }

            WriteLine();
        }
        #endregion

        #region switch statements
        /// <summary>
        /// Shows the use of the switch statement on an integer value
        /// </summary>
        static void ExecuteSwitch()
        {
            WriteLine("User input using loop and switch statement");

            while (true)
            {
                WriteLine("1 [C#], 2 [VB] 3 quit");
                Write("Please pick your language preference: ");

                string langChoice = ReadLine();
                int n = int.Parse(langChoice);

                switch (n)
                {
                    case 1:
                        WriteLine($"{n} Good choice, C# is a fine language.");
                        break;
                    case 2:
                        WriteLine($"{n} VB: OOP, multithreading, and more!");
                        break;
                    case 3:
                        break;
                    default:
                        WriteLine($"{n} Well...good luck with that!");
                        break;
                }
                WriteLine();
                if(n == 3)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Shows the use of a switch statement on a string.
        /// </summary>
        static void ExecuteSwitchOnString()
        {
            WriteLine("User input with switch on string");

            WriteLine("C# or VB");
            Write("Please pick your language preference: ");

            string langChoice = ReadLine();
            switch (langChoice)
            {
                case "C#":
                    WriteLine("Good choice, C# is a fine language.");
                    break;
                case "VB":
                    WriteLine("VB: OOP, multithreading and more!");
                    break;
                default:
                    WriteLine("Bad input - Well...good luck with that!");
                    break;
            }

            WriteLine();
        }

        /// <summary>
        /// Shows the use of a switch statement on an enum value (which is really an int)
        /// This is a bit advanced, and will be covered further in future classes.
        /// </summary>
        static void SwitchOnEnumExample()
        {
            WriteLine("User input using switch on enum");

            Write("Enter your favorite day of the week: ");
            DayOfWeek favDay;

            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), ReadLine());
            }
            catch (Exception)
            {
                WriteLine("Bad input!");
                return;
            }

            switch (favDay)
            {
                case DayOfWeek.Friday:
                    WriteLine("Yes, Friday rules!");
                    break;
                case DayOfWeek.Monday:
                    WriteLine("Monday, Another day, another dollar");
                    break;
                case DayOfWeek.Saturday:
                    WriteLine("Saturday, a great day indeed.");
                    break;
                case DayOfWeek.Sunday:
                    WriteLine("Sunday Football!!");
                    break;
                case DayOfWeek.Thursday:
                    WriteLine("Thursday .... Almost Friday...");
                    break;
                case DayOfWeek.Tuesday:
                    WriteLine("Tuesday ... At least it is not Monday");
                    break;
                case DayOfWeek.Wednesday:
                    WriteLine("Wednesday ... A fine day.");
                    break;
            }
            WriteLine();
        }
        #endregion
    }
}
