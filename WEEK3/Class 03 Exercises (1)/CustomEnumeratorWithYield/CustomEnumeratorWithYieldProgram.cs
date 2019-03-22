using System;
using CommonCar;
namespace CustomEnumeratorWithYield
{
    class CustomEnumeratorWithYieldProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the Yield Keyword *****\n");
            Garage carLot = new Garage();

            // This uses the Garage default enumerator

            Console.WriteLine("Show using the default iterator");


            foreach (Car c in carLot)
                Console.WriteLine(c);

            Console.WriteLine();

            // Get items using named iterator.

            Console.WriteLine("Show using GetTheCars(false)");
            foreach (Car c in carLot.GetTheCars(false))
                Console.WriteLine(c);
            Console.WriteLine();

            // Get items (in reverse!) using named iterator.

            Console.WriteLine("Show in reverse using GetTheCars(true)");
            foreach (Car c in carLot.GetTheCars(true))
                Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
