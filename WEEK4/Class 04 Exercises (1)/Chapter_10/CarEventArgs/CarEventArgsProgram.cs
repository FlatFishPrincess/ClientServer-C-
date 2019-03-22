using System;
using CommonCar;

namespace CarEventArgs
{
    class CarEventArgsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car myCar = new Car("SlugBug", 100, 10);

            // Register event handlers.
            myCar.AboutToBlowEvent += CarAboutToBlow;
            myCar.ExplodedEvent += CarExploded;

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                myCar.AccelerateUsingExplicitEvents(20);

            // now unregister CarExploded, so no message for this is given

            myCar.ExplodedEvent -= CarExploded;

            Console.WriteLine("\n***** Speeding up CarExploded event unregistered *****");
            for (int i = 0; i < 6; i++)
                myCar.AccelerateUsingExplicitEvents(20);

            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, EventArgs e)
        {
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car c)
            {
                CommonCar.CarEventArgs args = (CommonCar.CarEventArgs)e;
                Console.WriteLine("CarAboutToBlow - {0}: {1}", c.Name, args.msg);
            }
        }

        public static void CarExploded(object sender, EventArgs e)
        {
            if (sender is Car c)
            {
                CommonCar.CarEventArgs args = (CommonCar.CarEventArgs)e;
                Console.WriteLine("CarExploded {0}: {1}", c.Name, args.msg);
            }
        }
    }

}
