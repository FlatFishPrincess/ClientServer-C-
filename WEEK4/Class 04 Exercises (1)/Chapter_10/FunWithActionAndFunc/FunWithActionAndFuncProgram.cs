using System;

namespace FunWithActionAndFunc
{
    class FunWithActionAndFuncProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****\n");

            Action<string, ConsoleColor, int> actionTarget = DisplayMessage;

            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);

            actionTarget.Invoke($"Add() 40 + 40 = {result}", ConsoleColor.Red, 4);

            Func<int, int, string> funcTarget2 = SumToString;
            string sum = funcTarget2(90, 300);

            actionTarget.Invoke($"SumToString() 90 + 300 = {sum}", ConsoleColor.Blue, 2);

            Console.ReadLine();
        }

        // This is a target for the Action<> delegate. 
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text. 
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
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
    }
}