using CommonCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class CarDelegateProgram
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");

            // First, make a Car object.
            Car myCar = new Car("SlugBug", 100, 10);
            
            // register the handler, note anonymous class. Note the arg as a handler 
            // that conforms to the delegate method signature
            // If you change the method handler arguments below, you will get a compile time error.

            myCar.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            // This time, hold onto the delegate object,
            // so we can unregister later.
            // The Register function keeps a list of all the event handlers
            //  that conform to the delegate signature.
            
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            myCar.RegisterWithCarEngine(handler2);

            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                myCar.Accelerate(20);

            // Unregister from the second handler. 
            myCar.UnRegisterWithCarEngine(handler2);

            // We won't see the 'uppercase' message anymore!
            Console.WriteLine("***** Speeding up  but unregistered 2nd event handler*****");
            for (int i = 0; i < 6; i++)
                myCar.Accelerate(20);

            Console.ReadLine();
        }

 
        // We now have TWO methods that will be called by the Car
        // when sending notifications. 
        public static void OnCarEngineEvent( string msg )
        {
            Console.WriteLine("\nCar Event1 Message");
            Console.WriteLine("=> {0}", msg);
        }

        public static void OnCarEngineEvent2( string msg )
        {
            Console.WriteLine("Car Event2 Message");
            Console.WriteLine("=> {0}\n", msg.ToUpper());
        }
    }
}
