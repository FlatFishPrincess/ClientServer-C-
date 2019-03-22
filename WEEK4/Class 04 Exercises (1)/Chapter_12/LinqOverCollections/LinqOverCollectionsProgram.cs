using CommonCar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqOverCollections
{
    class LinqOverCollectionsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");

            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>() {
                new Car{ Name = "Henry", Color = "Silver", CurrentSpeed = 100, Make = "BMW"},
                new Car{ Name = "Daisy", Color = "Tan", CurrentSpeed = 90, Make = "BMW"},
                new Car{ Name = "Mary", Color = "Black", CurrentSpeed = 55, Make = "VW"},
                new Car{ Name = "Clunker", Color = "Rust", CurrentSpeed = 5, Make = "Yugo"},
                new Car{ Name = "Melvin", Color = "White", CurrentSpeed = 43, Make = "Ford"}
            };

            GetFastCars(myCars);
            Console.WriteLine();

            GetFastBMWs(myCars);
            Console.WriteLine();

            LINQOverArrayList();
            Console.WriteLine();

            OfTypeAsFilter();
            Console.WriteLine();

            Console.ReadLine();
        }

        static void GetFastCars(List<Car> myCars)
        {
            // Find all Car objects in the List<>, where the CurrentSpeed is
            // greater than 55.
            var fastCars = from c in myCars
                           where c.CurrentSpeed > 55
                           select c;

            Console.WriteLine("LINQ: Cars going over 55");

            DisplayCarInfo(fastCars);          
        }

        static void GetFastBMWs(List<Car> myCars)
        {
            // Find the fast BMWs!
            var fastCars = from c in myCars
                           where c.CurrentSpeed > 90 && c.Make == "BMW"
                           select c;
            Console.WriteLine("LINQ: BMWs going over 90");

            DisplayCarInfo(fastCars);         
        }

        static void LINQOverArrayList()
        {

            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() {
                new Car{ Name = "Henry", Color = "Silver", CurrentSpeed = 100, Make = "BMW"},
                new Car{ Name = "Daisy", Color = "Tan", CurrentSpeed = 90, Make = "BMW"},
                new Car{ Name = "Mary", Color = "Black", CurrentSpeed = 55, Make = "VW"},
                new Car{ Name = "Clunker", Color = "Rust", CurrentSpeed = 5, Make = "Yugo"},
                new Car{ Name = "Melvin", Color = "White", CurrentSpeed = 43, Make = "Ford"}
              };

            Console.WriteLine("LINQ over ArrayList: Cars going over 55");

            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnumerable = myCars.OfType<Car>();

            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnumerable
                           where c.CurrentSpeed > 55
                           select c;

            DisplayCarInfo(fastCars);
        }

        static void DisplayCarInfo(IEnumerable<Car> carList)
        {
            foreach( var car in carList)
                Console.WriteLine($"{car.Name} {car.Make} Speed = {car.CurrentSpeed}");
        }

        static void OfTypeAsFilter()
        {
            // Extract the ints from the ArrayList.
            ArrayList myStuff = new ArrayList();

            myStuff.AddRange(new object[] {
                10, 400, 8, false, new Car(), "string data"
            });

            // only pull out the integers from the ArrayList

            var myInts = myStuff.OfType<int>();

            Console.WriteLine("Pulling out integers from ArrayList of mixed types");

            // Prints out 10, 400, and 8.
            foreach (int i in myInts)
            {
                Console.WriteLine("Int value: {0}", i);
            }
        }
    }
}
