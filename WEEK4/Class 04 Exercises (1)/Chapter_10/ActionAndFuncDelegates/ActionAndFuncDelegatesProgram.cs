using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    class ActionAndFuncDelegatesProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****\n");

            // Use the Action<> delegate to point to DisplayMessage. 
            Action<string, ConsoleColor, int> actionTarget = 
                new Action<string, ConsoleColor, int>(DisplayMessage);

            // do the same thing but no need to use new

            Action<string, ConsoleColor, int> actionTarget2 = DisplayMessage;

            // fire off each

            actionTarget("Action Message!", ConsoleColor.Yellow, 5);
            actionTarget2("Second Action Message", ConsoleColor.Blue, 8);

            // now set a different message function for the same target

            actionTarget = DisplayDifferentMessage;

            // and make the second target use the first message

            actionTarget2 = DisplayMessage;

            // now fire both of them

            actionTarget("A Different Action Message!", ConsoleColor.Green, 5);

            actionTarget2("Second Action Message", ConsoleColor.Red, 3);

            // assign Add method to target and invoke

            Func<int, int, int> funcTarget = new Func<int, int, int>(Add);

            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);


            // do the same with SumToString. Note no need for explicit Invoke()

            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            string sum = funcTarget2(90, 300);
            Console.WriteLine($"SumToString 90 + 300 {sum}");           

            // Same as original target func, but simply using assignment
            Func<int, int, int> funcTarget3 = Add;
            int result2 = funcTarget3.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result2);

            // same as above, but changing target to Subtract.
            funcTarget3 = Subtract;
            Console.WriteLine($"50 - 17 = {funcTarget3(50, 17)}");

            Func<int, int, string> funcTarget4 = SumToString;
            string sum2 = funcTarget4(80, 200);
            Console.WriteLine($"SumToString 80 + 200 {sum2}");

            Console.ReadLine();
        }

        // This is a target for the Action<> delegate. 
        static void DisplayMessage(string msg, ConsoleColor txtColor, int displayCount)
        {
            // Set color of console text. 
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            Console.WriteLine($"DisplayMessage {displayCount} times");

            for (int i = 0; i < displayCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore color. 
            Console.ForegroundColor = previous;
        }

        static void DisplayDifferentMessage(string msg, ConsoleColor txtColor, int displayCount)
        {
            // Set color of console text. 
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            Console.WriteLine($"DisplayDifferentMessage {displayCount} times");

            for (int i = 0; i < displayCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore color. 
            Console.ForegroundColor = previous;
        }

        // Targets for the Func<> delegate. 
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        static int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
