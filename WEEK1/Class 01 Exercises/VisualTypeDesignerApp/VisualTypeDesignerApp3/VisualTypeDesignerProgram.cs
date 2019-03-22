using System;
using static System.Console;

namespace VisualTypeDesigner
{
    class VisualTypeDesignerProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine(new SportsCar().GetName());

            Car myCar = new Car()
            {
                Name = "Honda"
            };

            WriteLine(myCar.Name);
            Console.ReadLine();
        }
    }

    public class Car
    {
        /// <summary>
        /// The name of the car
        /// </summary>
        public string Name;
    }

    public class SportsCar : Car
    {
        /// <summary>
        /// gets the name of the car
        /// </summary>
        public string GetName()
        {
            Name = "Old Wreck";
            return Name;
        }
    }
}
