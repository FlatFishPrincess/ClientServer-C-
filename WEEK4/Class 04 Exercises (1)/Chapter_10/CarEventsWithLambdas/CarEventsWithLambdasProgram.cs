using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarEventsWithLambdas
{
    class CarEventsWithLambdasProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** More Fun with Lambdas *****\n");

            // Make a car as usual.
            Car myCar = new Car("SlugBug", 100, 10);

            // Hook into events with lambdas!
            myCar.AboutToBlow += (sender, e) => Console.WriteLine(e.msg); 
            myCar.Exploded += (sender, e) => Console.WriteLine(e.msg); 

            // Speed up (this will generate the events).
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                myCar.Accelerate(20);

            Console.ReadLine();
        }
    }
}
