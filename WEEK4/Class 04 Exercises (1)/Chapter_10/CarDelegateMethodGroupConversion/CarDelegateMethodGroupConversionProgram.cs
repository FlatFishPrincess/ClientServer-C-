using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCar;

namespace CarDelegateMethodGroupConversion
{
    class CarDelegateMethodGroupConversionProgram
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Method Group Conversion *****\n");
            Car myCar = new Car();

            myCar.MaxSpeed = 80; // set the max speed

            Console.WriteLine($"MaxSpeed is {myCar.MaxSpeed}");

            // Register the simple method name. Note it has to correspond to 
            // delegate signature.

            myCar.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                myCar.Accelerate(20);

            // Unregister the simple method name.
            myCar.UnRegisterWithCarEngine(CallMeHere);

            Console.WriteLine("Unregister CallMeHere, message from handler now stops");

            // No more notifications!
            for (int i = 0; i < 6; i++)
                myCar.Accelerate(20);

            Console.ReadLine();
        }

        static void CallMeHere( string msg )
        {
            Console.WriteLine("CallMeHere Message: {0}", msg);
        }
    }
}
