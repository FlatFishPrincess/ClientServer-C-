using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessMultipleExceptions
{
    class ProcessMultipleExceptionsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Handling Multiple Exceptions *****\n");
            Car myCar = new Car("Rusty", 90, 1);

            Console.WriteLine($"Auto initialized: {myCar}");

            #region Try/catch logic
            try
            {
                // Trip Arg out of range exception.
                myCar.Accelerate(1000);
            }
            // Just for fun...
            catch (CarIsDeadException e) when (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                Console.WriteLine("Catching car is dead!");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Catching ArgumentOutOfRangeException " + e.InnerException);

                Console.WriteLine(e.Message);
            }
            // This will catch any other exception
            // beyond CarIsDeadException or
            // ArgumentOutOfRangeException.
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // This will always occur. Exception or not.
                Console.WriteLine("Finally exception");
                myCar.CrankTunes(true);
            }
            #endregion

            Console.ReadLine();
        }
    }
    /// <summary>
    /// Car class derived from CommonCar 
    ///     Just reuse the base constructor
    ///     But override the Accelerate method to include exception processing
    /// </summary>
    class Car : CommonCar.Car
    {
        public Car(string name, int speed, int id) : base(name, speed, id)
        {

        }
        public override void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", CarName);
            else
            {
                CurrentSpeed += delta;

                if (CurrentSpeed >= maxSpeed)
                {
                    carIsDead = true;

                    // throw new ArgumentOutOfRangeException();

                    // We need to call the HelpLink property, thus we need
                    // to create a local variable before throwing the Exception object.

                    //Exception ex =
                    //  new Exception($"{CarName} has overheated! {CurrentSpeed} Over max speed of {MaxSpeed}");

                    CarIsDeadException ex =
                        new CarIsDeadException($"{CarName} has overheated! {CurrentSpeed} Over max speed of {maxSpeed}")
                        {
                            HelpLink = "http://www.CarsRUs.com"
                        };

                    // Stuff in custom data regarding the error.
                    ex.Data.Add("TimeStamp",
                      string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");

                    CurrentSpeed = 0;

                    ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("Too much acceleration!");
                    Exception ex3 = new Exception("Generic problem with acceleration");

                    // change this to ex1 or ex2 or ex3 to see how each exception is handled

                    throw ex3;


                }
                else
                {
                    Console.WriteLine("=> {0} CurrentSpeed = {1}, {2}", CarName, CurrentSpeed, carRadio);
                }
            }
        }

    }

}
