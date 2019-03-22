using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonCar;

namespace GenericCarEventArgs
{
    class GenericCarEventArgsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car myCar = new Car("SlugBug", 100, 10);

            // Register event handlers.
            myCar.GenericAboutToBlowEvent += CarAboutToBlow;
            myCar.GenericExplodedEvent += CarExploded;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                myCar.AccelerateUsingExplicitEvents(20);

            // now unregister CarExploded, so no message for this is given

            myCar.GenericExplodedEvent -= CarExploded;

            Console.WriteLine("\n***** Speeding up CarExloded event unregistered *****");
            for (int i = 0; i < 6; i++)
                myCar.AccelerateUsingExplicitEvents(20);

            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car c)
            {
                Console.WriteLine("CarAboutToBlow - {0}: {1}", c.Name, e.msg);
            }
        }

        public static void CarExploded(object sender, CarEventArgs e)
        {
            if (sender is Car c)
            {
                Console.WriteLine("CarExploded - {0}: {1}", c.Name, e.msg);
            }

        }
    }
}
