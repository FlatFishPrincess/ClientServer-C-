using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonCar
{

    /// <summary>
    /// Introduce CommonCar space, which can be used by all other code in this project.
    /// This is part of the CommonCar shared project
    /// 
    /// Our trusty Car class, but this one implements IComparable
    /// </summary>

    class Car : IComparable
    {
        // Constant for maximum speed.
        public const int maxSpeed = 100;

        // Car properties.

        public int CurrentSpeed { get; set; }
        public string CarName { get; set; } = ""; // set this to the null string rather than null reference
        public int CarID { get; set; }

        // Property to return the CarNameComparer. Note static!!

        public static IComparer SortByCarName
        {
            get { return (IComparer)new CarNameComparer(); }
        }


        // Car fields

        /// <summary>
        /// Is the car operational?
        /// </summary>
        protected bool carIsDead;

        /// <summary>
        /// All cars have a radio. 
        /// </summary>
        public Radio carRadio = new Radio();

        // Constructors.

        public Car() { }

        /// <summary>
        /// Set name, speed, and id
        /// </summary>
        /// <param name="name">Car Name</param>
        /// <param name="speed">Initial speed</param>
        /// <param name="id">Car id</param>
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            CarName = name;
            CarID = id;
            carIsDead = false;
        }

        /// <summary>
        /// Turn on or off the radio
        /// </summary>
        /// <param name="state">true to turn on, false to turn off</param>
        public void CrankTunes(bool state)
        {
            // Delegate request to inner object.
            carRadio.TurnOn(state);
            Console.WriteLine($"{CarName} {carRadio}");
        }

        /// <summary>
        /// Accelerate method. 
        ///     Tests to see if beyond max speed, and throws an exception.
        ///     Virtual to allow for override (custom exception)
        /// </summary>
        /// <param name="increasedSpeed">Amount of acceleration</param>

        public virtual void Accelerate(int increasedSpeed)
        {

            if (carIsDead)
                Console.WriteLine("{0} is dead - not working!", CarName);
            else
            {
                CurrentSpeed += increasedSpeed;
                if (CurrentSpeed >= maxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;

                    // We need to call the HelpLink property, thus we need
                    // to create a local variable before throwing the Exception object.
                    Exception ex =
                      new Exception(string.Format("{0} has overheated!", CarName))
                      {
                          HelpLink = "http://www.CarsRUs.com"
                      };

                    // Stuff in custom data regarding the error.
                    ex.Data.Add("TimeStamp",
                      string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine($"Accelerated by {increasedSpeed} for {this}");
            }
        }

        // IComparable implementation. 
        /*
        int IComparable.CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
            {
                if (this.CarID > temp.CarID)
                    return 1;
                if (this.CarID < temp.CarID)
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parameter is not a Car!");
        }
        */

        // CompareTo method does exactly the same as above, just uses CompareTo method from CarID (an integer).
        //  Integers have a default CompareTo method, which is why this works.
        // fully qualified name is below.

        int IComparable.CompareTo(object obj)
        {
            if (obj is Car)
                return CarID.CompareTo((obj as Car).CarID);
            else
                throw new ArgumentException("Parameter is not a Car!");
        }

        public override string ToString()
        {
            return $"{CarID} {CarName} Speed {CurrentSpeed} {carRadio}";
        }
    }

    /// <summary>
    /// Compare the CarName of two Car objects
    /// </summary>
    public class CarNameComparer : IComparer
    {
        // Test the car name of each object.
        int IComparer.Compare(object o1, object o2)
        {

            Car t1 = o1 as Car;
            Car t2 = o2 as Car;

            if (o1 is Car && o2 is Car)
                return (String.Compare((o1 as Car).CarName, (o2 as Car).CarName));
            //if (t1 != null && t2 != null)
            //    return String.Compare(t1.CarName, t2.CarName);
            else
                throw new ArgumentException("Parameter is not a Car!");
        }
    }

    /// <summary>
    /// Simple Radio class - can either turn it on or off using boolean
    /// </summary>
    class Radio
    {
        private bool RadioState = false;

        public void TurnOn(bool newState)
        {
            RadioState = newState;
        }

        public override string ToString()
        {
            return string.Format("Radio is {0}", RadioState ? "On" : "Off");
        }
    }
}
