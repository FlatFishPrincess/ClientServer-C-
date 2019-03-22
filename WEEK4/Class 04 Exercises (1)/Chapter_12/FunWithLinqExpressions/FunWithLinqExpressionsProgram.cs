using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; }= "";
        public int NumberInStock { get; set; }

        public override string ToString()
        {
            return $"Name = {Name}, Description = {Description}, Number in Stock = {NumberInStock}";
        }
    }

    class FunWithLinqExpressionsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Query Expressions *****\n");

            // This array will be the basis of our testing...
            ProductInfo[] itemsInStock = new[] {
                new ProductInfo{ Name = "Mac's Coffee",
                                Description = "Coffee with TEETH",
                                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk",
                                Description = "Milk cow's love",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",
                                Description = "Bland as Possible",
                                NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops",
                                Description = "Cheezy, peppery goodness",
                                NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",
                                Description = "From the tap to your wallet",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",
                                Description = "Everyone loves pizza!",
                                NumberInStock = 73}
                };

            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW", "Honda", "Toyota", "Mercedes", "Ford", "Fiat" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec", "Toyota", "Honda", "Chrysler", "Dodge" };


            // We will call various methods here!
            ListProductNames(itemsInStock);
            Console.WriteLine();

            GetOverstock(itemsInStock);
            Console.WriteLine();

            GetNamesAndDescriptions(itemsInStock);
            Console.WriteLine();

            GetCountFromQuery();
            Console.WriteLine();

            SortByProductNames(itemsInStock);
            Console.WriteLine();

            ReverseEverything(itemsInStock);
            Console.WriteLine();

            DisplayConcat(myCars, yourCars);
            Console.WriteLine();

            DisplayJoin(myCars, yourCars);
            Console.WriteLine();

            DisplayDiff(myCars, yourCars);
            Console.WriteLine();

            DisplayIntersection(myCars, yourCars);
            Console.WriteLine();

            DisplayUnion(myCars, yourCars);
            Console.WriteLine();

            DisplayConcatNoDups(myCars, yourCars);
            Console.WriteLine();

            DisplayContains(myCars, "Honda");
            Console.WriteLine();

            DisplayGroupBy(myCars, yourCars);
            Console.WriteLine();

            AggregateOps();
            Console.WriteLine();

            Console.ReadLine();
        }

        static void SelectEverything(ProductInfo[] products)
        {
            // Get everything!
            Console.WriteLine("All product details:");
            var allProducts = from p in products
                              select p;

            allProducts = products.Select(p => p);

            foreach (var product in allProducts)
            {
                Console.WriteLine(product);
            }
        }

        static void ListProductNames(ProductInfo[] products)
        {
            // Now get only the names of the products.
            Console.WriteLine("Only product names:");
            var names = from p in products select p.Name;

            foreach (var name in names)
            {
                Console.WriteLine($"Name: {name}");
            }
        }

        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("The overstock items:");

            // Get only the items where we have more than
            // 25 in stock.
            var overstock = from p in products
                            where p.NumberInStock > 25
                            select p;

            overstock = products.Where(p => p.NumberInStock > 25);

            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c);
            }
        }

        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products
                           select new { p.Name, p.Description };

            nameDesc = products.Select(p => new { p.Name, p.Description });

            foreach (var item in nameDesc)
            {
                // Could also use Name and Description properties directly.
                // note the output since both properties of the anon class are strings
                Console.WriteLine(item);
            }
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                                "Fallout 3", "Daxter", "System Shock 2"};

            Console.WriteLine("GetCountFromQuery(): videogames");

            foreach (string game in currentVideoGames)
                Console.WriteLine(game);

            // Get count from the query.
            int selectedVideoGames =
            (from g in currentVideoGames
             where g.Length > 6
             select g).Count();

            // Print out the number of items.
            Console.WriteLine($"{selectedVideoGames} Video games with name length > 6");

            selectedVideoGames = currentVideoGames.Where(g => g.Length > 6).Count();

            Console.WriteLine($"{selectedVideoGames} Video games with name length > 6 (using linq methods");

        }

        static void ReverseEverything(ProductInfo[] products)
        {
            // example: linq syntax and linq methods BOTH produce the same results
            // try this by using the second one

            Console.WriteLine("ReverseEverything()");
            var allProducts = from p in products
                              select p;

            var allProducts2 = products.Select(p => p).Reverse();

            foreach (var product in allProducts2.Reverse())
            {
                Console.WriteLine(product);
            }
        }

        static void SortByProductNames(ProductInfo[] products)
        {
            // Get names of products, alphabetized.
            var sortedProducts = from p in products orderby p.Name select p;

            var sortedProducts2 = products.OrderBy(p => p.Name);

            Console.WriteLine("SortByProductName()");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine(p);
            }
        }

        static void DisplayJoin(List<string> myCars, List<string> yourCars)
        {
            var carJoin = from myCar in myCars
                          join yourCar in yourCars
                          on myCar equals yourCar
                          select myCar;
            Console.WriteLine("DisplayJoin()");

            foreach (string s in carJoin)
                Console.WriteLine(s); // Prints Aztec, Honda, Toyota and BMW.


        }
        static void DisplayDiff(List<string> myCars, List<string> yourCars)
        {
            // a bit silly as the below could simply be used

            var carDiff2 = myCars.Except(yourCars);

            var carDiff = (from c in myCars select c)
              .Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s); // Prints Yugo.
        }

        static void DisplayIntersection(List<string> myCars, List<string> yourCars)
        {
            // Get the common members.
            var carIntersect = (from c in myCars select c)
              .Intersect(from c2 in yourCars select c2);

            Console.WriteLine("DisplayIntersection()");
 
            foreach (string s in carIntersect)
                Console.WriteLine(s); // Prints Aztec and BMW.
        }

        static void DisplayUnion(List<string> myCars, List<string> yourCars)
        {
            // Get the union of these containers.
            var carUnion = (from c in myCars select c)
            .Union(from c2 in yourCars select c2);

            Console.WriteLine("DisplayUnion()");
            foreach (string s in carUnion)
                Console.WriteLine(s); // Prints all common members.
        }

        static void DisplayConcat(List<string> myCars, List<string> yourCars)
        {
            Console.WriteLine("DisplayConcat()");

            var carConcat = (from c in myCars select c)
              .Concat(from c2 in yourCars select c2);

            // Prints:
            // Yugo Aztec BMW BMW Saab Aztec.
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }

        static void DisplayConcatNoDups(List<string> myCars, List<string> yourCars)
        {
            var carConcat = (from c in myCars select c)
              .Concat(from c2 in yourCars select c2)
              .Distinct();
            Console.WriteLine("DisplayConcatNoDups()");

            // Prints:
            // Yugo Aztec BMW Saab Aztec.
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }

        static void DisplayGroupBy(List<string> myCars, List<string> yourCars)
        {
            var cars = myCars.Concat(yourCars).Distinct();

            var carGroups = from car in cars
                            group car by car[0] into groups
                            orderby groups.Key
                            select groups;

            var carGroups2 = cars.GroupBy(p => p[0]).OrderBy(p => p.Key);

            Console.WriteLine("DisplayGroupBy()");

            foreach (var carGroup in carGroups2)
            {
                Console.WriteLine(carGroup.Key);
                foreach (var car in carGroup)
                    Console.WriteLine(" " + car);
            }

        }

        /// <summary>
        /// Example of using where vs contains in linq
        /// </summary>
        /// <param name="stringList"></param>
        /// <param name="searchString"></param>
        static void DisplayContains(List<string> stringList, string searchString)
        {
            // use filter to search for EXACT match

            var found = from s in stringList
                        where s == searchString
                        select s;

            var found2 = stringList.Contains(searchString);

            Console.WriteLine("DisplayContains()");
            Console.Write("List:");
            foreach (string s in stringList)
                Console.Write(" " + s);
            Console.WriteLine();
            Console.Write("Found:");
            foreach (string s in found)
                Console.Write(" " + s);
            Console.WriteLine();

            Console.WriteLine($"Contains {searchString}: {found2}");
        }


        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            Console.WriteLine("AggregateOps()");

            double ToFarenheit(double temp) => (temp * 1.8) + 32;

            // Various aggregation examples.
            // note the use of linq methods and lambda

            Console.Write("Temperatures:");
            foreach (double temp in winterTemps)
                Console.Write($" {temp}C ({ToFarenheit(temp)}F)");
            Console.WriteLine();

            Console.WriteLine("Max temp: {0}",
              (from t in winterTemps select t).Max());

            Console.WriteLine("Max temp in Farenheit {0}",
                winterTemps.Max(p => ToFarenheit(p))
                );

            Console.WriteLine("Min temp: {0}",
              (from t in winterTemps select t).Min());

            Console.WriteLine("Min temp in Farenheit {0}",
                winterTemps.Select(p => ToFarenheit(p)).Min()
                );


            Console.WriteLine("Avarage temp: {0}",
              (from t in winterTemps select t).Average());
            Console.WriteLine("Average temp in Farenheit {0}",
                winterTemps.Select(p => ToFarenheit(p)).Average()
                );


            Console.WriteLine("Sum of all temps: {0}",
              (from t in winterTemps select t).Sum());
        }
    }
}
