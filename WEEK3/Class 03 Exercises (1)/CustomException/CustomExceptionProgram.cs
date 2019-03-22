using System;
using CommonCar;
namespace CustomException
{
    class CustomExceptionProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Exceptions *****\n");
            Car myCar = new Car("Rusty", 100, 1);
            Console.WriteLine("Car initialized: " + myCar);

            try
            {
                // Trip exception.
                Console.WriteLine("Accelerating another 10");
                myCar.Accelerate(10);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine("HELP!!!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
  
            }
            Console.ReadLine();
        }

    }

    /// <summary>
    /// Class that overrides Accelerate in order to demonstrate a custom exception
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

                if (CurrentSpeed > maxSpeed)
                {
                    carIsDead = true;

                    // 
                    throw new CarIsDeadException(
                        $"{CarName} has overheated! {CurrentSpeed} Over max speed of {maxSpeed}", // error message
                        "Cause: You have a lead foot",                                            // cause
                        DateTime.Now                                                              // timestamp
                        );

                }
                else
                    Console.WriteLine("=> {0} CurrentSpeed = {1}, {2}", CarName, CurrentSpeed, carRadio);
            }
        }
    }

}
