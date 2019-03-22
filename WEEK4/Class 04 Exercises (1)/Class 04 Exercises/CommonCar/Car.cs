using System;

namespace CommonCar
{
    /// <summary>
    /// Car class used for all exercises in Class 04
    /// </summary>
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string Name { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }

        // Class constructors.
        public Car() { }
        public Car(string name, int maxSpeed, int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
            Name = name;
        }

        /// <summary>
        /// Define a delegate type.Note the handler simply has a string arg, which is used as a message to the user
        /// </summary>
        /// <param name="msgForCaller"></param>
        public delegate void CarEngineHandler(string msgForCaller);

        /// <summary>
        /// Define a member variable of this delegate.
        /// </summary>
        private CarEngineHandler listOfHandlers;

        /// <summary>
        /// Add registration function for the caller. Note use of method group here
        /// </summary>
        /// <param name="methodToCall">Delegate to register</param>
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (listOfHandlers == null)
            {
                listOfHandlers = methodToCall;   // start the list
            }
            else
            {
                listOfHandlers += methodToCall; // add to the list
            }
        }

        /// <summary>
        /// Remove the registration for the handler.
        /// </summary>
        /// <param name="methodToCall">Must be a handler (delegate) already registered</param>
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        /// <summary>
        /// Implement the Accelerate() method to invoke the delegate’s invocation list under the correct circumstances.
        /// </summary>
        /// <param name="delta"></param>
        public void Accelerate(int delta)
        {
            // If this car is 'dead', send dead message.
            if (CurrentSpeed >= MaxSpeed)
            {
                // call all of the handlers registered using one string arg

                listOfHandlers?.Invoke($"Sorry, {Name} is dead..., Speed {CurrentSpeed}, Accelerate {delta}");
            }
            else
            {
                CurrentSpeed += delta;

                // Is this car 'almost dead'?
                if ((MaxSpeed - CurrentSpeed) == 10)
                {
                    // again call all of the handlers registered
                    listOfHandlers?.Invoke($"Careful {Name}!  Gonna blow! Speed {CurrentSpeed}, Accelerate {delta}");
                }
                else
                {
                    Console.WriteLine($"Name {Name} Speed {CurrentSpeed}, Accelerate {delta}");
                }
            }
        }

        // Lets do this with explicit events instead of delegates
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

            // In main method, use AboutToBlow event to store methods
            //myCar.AboutToBlow += CarIsAlmostDoomed;
            //myCar.AboutToBlow += CarAboutToBlow;

        public EventHandler ExplodedEvent;    // car explodes
        public EventHandler AboutToBlowEvent; // car gets close to exploding

        // same as above but use generics
        public event EventHandler<CarEventArgs> GenericExplodedEvent;
        public event EventHandler<CarEventArgs> GenericAboutToBlowEvent;

        /// <summary>
        /// Accelerate the car by an amount until max is reached, then explicit events are called
        /// </summary>
        /// <param name="delta"></param>
        public void AccelerateUsingExplicitEvents(int delta)
        {
            // If this car is 'dead', fire Exploded event
            if (CurrentSpeed >= MaxSpeed)
            {
                string message = $"Exploded {Name} Speed {CurrentSpeed}, Accelerate {delta}";
                Exploded?.Invoke(message);
                ExplodedEvent?.Invoke(this, new CarEventArgs(message));
                GenericExplodedEvent?.Invoke(this, new CarEventArgs(message));


            }
            else
            {
                CurrentSpeed += delta;

                // Is this car 'almost dead'?
                if ((MaxSpeed - CurrentSpeed) == 10)
                {
                    // fire AboutToBlow event
                    string message = $"AboutToBlow {Name} Speed {CurrentSpeed}, Accelerate {delta}";
                    AboutToBlow?.Invoke(message);
                    AboutToBlowEvent?.Invoke(this, new CarEventArgs(message));
                    GenericAboutToBlowEvent?.Invoke(this, new CarEventArgs(message));

                }
                else
                {
                    Console.WriteLine($"Accelerating {Name} Speed {CurrentSpeed}, Accelerate {delta}");
                }
            }
        }
    }

    /// <summary>
    /// For use with car events
    /// Just contains a holder for the message
    /// </summary>
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }

}
