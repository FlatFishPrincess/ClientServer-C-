using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicDelegateProblem
{
 
    
    class PublicDelegateProblemProgram
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Agh!  No Encapsulation! *****\n");
            // Make a Car.
            Car myCar = new Car
            {
                // We have direct access to the delegate!
                listOfHandlers = new Car.CarEngineHandler(CallWhenExploded)
            };
            myCar.Accelerate(10); // write the console here.

            // We can now assign to a whole new object...
            // confusing at best.
            myCar.listOfHandlers = new Car.CarEngineHandler(CallHereToo);
            myCar.Accelerate(30);

            // The caller can also directly invoke the delegate!
            myCar.listOfHandlers.Invoke("Handler invoked by caller directly!");
            Console.ReadLine();
        }

        static void CallWhenExploded( string msg )
        {
            Console.WriteLine($"CallWhenExploded handler: {msg}");
        }

        static void CallHereToo( string msg )
        {
            Console.WriteLine($"CallHereToo handler: {msg}");
        }
    }

    // If we expose a handler list (really a delegate object) as public,
    //   it can be overwritten, or the whole list can be invoked externally.
    // Better to hide it, and devise register/invoke methods to gateway use.

    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        // Now a public member!
        // Note the list can be expanded by using +=

        public CarEngineHandler listOfHandlers;

        // Just fire out the Exploded notification.
        public void Accelerate(int delta)
        {
            listOfHandlers?.Invoke($"Handler called in Accelerate({delta})");
        }
    }
}
