using System;
using CommonCar; // note we are using classes from the shared project

namespace ComparableCar
{
    class ComparableCarProgram
    {
        /// <summary>
        /// Given an array of Cars, properly initialized, sort the array with custom comparison functions
        /// using IComparable interface or an IComparer helper class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Sorting *****\n");

            // Make an array of Car objects.
            Car[] myAutos = new Car[]
            {
                new Car() { CarName = "Rusty", CurrentSpeed = 80, CarID = 1},
                new Car() { CarName = "Mary", CurrentSpeed = 40, CarID = 234},
                new Car() { CarName = "Viper", CurrentSpeed = 40, CarID = 34},
                new Car() { CarName = "Mel", CurrentSpeed = 40, CarID = 4},
                new Car() { CarName = "Chucky", CurrentSpeed = 40, CarID = 5},
                // null
            };

            // Display current array.

            DisplayAutos(myAutos, "Original set of cars:");

            // Now, sort them using IComparable!
            Array.Sort(myAutos);
            Console.WriteLine();

            myAutos[2].CrankTunes(true);
            myAutos[4].CrankTunes(true);

            // Display sorted array.
            DisplayAutos(myAutos, "Cars sorted by CarID using CompareTo method, radio turned on for a few:");

            // reverse the array

            Array.Reverse(myAutos);
            DisplayAutos(myAutos, "Cars sorted in reverse order by CarID, uses prior CompareTo:");

            // Now sort by CarName, but use the specific Comparer class

            Array.Sort(myAutos, new CarNameComparer());
            DisplayAutos(myAutos, "Cars sorted by CarName using CarNameComparer() explicitly:");

            // reverse the array

            Array.Reverse(myAutos);
            DisplayAutos(myAutos, "Cars sorted in reverse order by CarName (now note use of Comparer):");

            // Sorting by CarName made a bit cleaner.
            Array.Sort(myAutos, Car.SortByCarName);
            DisplayAutos(myAutos, "Cars sorted by CarName using Comparer returned by SortByCarName method in Car:");

            Console.ReadLine();
        }

        /// <summary>
        /// Display fields for each Car object in an array
        /// </summary>
        /// <param name="autos">Array holding Car objects</param>
        /// <param name="header"> Optional header to be displayed on the line before Car object info</param>
        static void DisplayAutos(Car[] autos, string header = null)
        {
            if (header != null)
                Console.WriteLine(header);
            foreach (Car c in autos)
                if (c != null)
                    Console.WriteLine(c);
            Console.WriteLine();
        }
    }
 
}
