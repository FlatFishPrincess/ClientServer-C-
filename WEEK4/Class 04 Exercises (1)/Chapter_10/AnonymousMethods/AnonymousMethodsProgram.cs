using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonCar;

namespace AnonymousMethods
{
    class AnonymousMethodsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Anonymous Delegate Methods *****\n");
            CommonCar.Car myCar = new CommonCar.Car("SlugBug", 100, 10);

            int aboutToBlowCounter = 0;

            // Register event handlers as anonymous methods.
            myCar.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("AboutToBlow Event - Eek! Going too fast!");
            };

            myCar.AboutToBlow += delegate(string message)
            {
                aboutToBlowCounter++;
                Console.WriteLine("AboutToBlow Event - Message from Car: {0}", message);
            };

            myCar.Exploded += delegate(string message)
            {
                Console.WriteLine("Exploded Event - Fatal Message from Car: {0}", message);
            };

            myCar.GenericExplodedEvent += delegate (object s, CarEventArgs c)
            {
                Console.WriteLine("Generic Exploded Event - Fatal Message from Car: {0}", c.msg);
            };

            // This will eventually trigger the events.
            for (int i = 0; i < 15; i++)
                myCar.AccelerateUsingExplicitEvents(10);

            Console.WriteLine("AboutToBlow event was fired {0} times.", aboutToBlowCounter);
            Console.ReadLine();
        }
    }
}
