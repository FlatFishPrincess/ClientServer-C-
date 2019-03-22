using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMethods
{
    /// <summary>
    /// Demonstrate use of Linq with internal operators (preferred) or
    /// Linq methods. Args for Linq methods need to be a delegate: 
    ///    anonymous, Func, lambda, ...
    ///    and are demonstrated by the various methods below.
    /// </summary>
    class LinqMethodsProgram
    {
        static void Main(string[] args)
        {
            // Our list of strings, happens to be video games.
            // All of the methods will be looking for a blank in the string
            //
            // Note that our string array implements IEnumerable, which each
            // method takes as an arg.

            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2", "Two For The Road"};

            QueryStringWithOperators(currentVideoGames);
            Console.WriteLine();

            QueryStringsWithLambdas(currentVideoGames);
            Console.WriteLine();

            QueryStringsWitLambdasBrokenDown(currentVideoGames);
            Console.WriteLine();

            QueryStringsWithAnonymousMethods(currentVideoGames);
            Console.WriteLine();

            VeryComplexQueryExpression.QueryStringsWithFuncDelegates(currentVideoGames);
            Console.WriteLine();

            Console.ReadLine();
        }
        /// <summary>
        /// Query a list of strings using standard Linq operators.
        /// This is easy to read and is preferred.
        /// </summary>
        /// <param name="list"></param>
        static void QueryStringWithOperators(IEnumerable<string> list)
        {
            Console.WriteLine("***** Using LINQ Query Operators *****");

            var subset = from item in list
                         where item.Contains(" ")
                         orderby item
                         select item;

            foreach (string item in subset)
                Console.WriteLine("Sorted Item: {0}", item);
        }

        /// <summary>
        /// Query the list using Linq methods and lambdas as args to the methods
        /// </summary>
        /// <param name="list"></param>
        static void QueryStringsWithLambdas(IEnumerable<string> list)
        {
            Console.WriteLine("***** Using LINQ Methods Syntax with lambdas *****");

            // Build a query expression using extension methods
            // which is granted to the Enumerable type.
            //  item => item seems a bit silly, but a Func is needed as arg.

            var subset = list
                .Where(item => item.Contains(" "))
                .OrderBy(item => item)
                .Select(item => item);

            // Print out the results.
            foreach (var item in subset)
                Console.WriteLine("Sorted Item: {0}", item);
            Console.WriteLine();

        }

        /// <summary>
        /// Query the list using Linq methods and lambdas as args to the methods.
        /// Linq methods are invoked one by one instead of concatenation. Same result
        /// as prior method.
        /// </summary>
        /// <param name="list"></param>
        static void QueryStringsWitLambdasBrokenDown(IEnumerable<string> list)
        {
            Console.WriteLine("***** Using LINQ Method Syntax with lambdas Broken Down *****");

            // Break it down!
            var listWithSpaces = list.Where(item => item.Contains(" "));
            var orderedList = listWithSpaces.OrderByDescending(item => item);
            var subset = orderedList.Select(item => item);  // redundant, just an example

            foreach (var item in listWithSpaces)
                Console.WriteLine($"Items with spaces: Item: {item}");

            foreach (var item in subset)
                Console.WriteLine($"Items with spaces Sorted Descending: Item: {item}");

            Console.WriteLine();
        }

        /// <summary>
        /// Query the list using Linq methods and anonymous delegate methods as args
        /// </summary>
        /// <param name="list"></param>
        static void QueryStringsWithAnonymousMethods(IEnumerable<string> list)
        {
            Console.WriteLine("***** Using LINQ Methods Syntax with Anonymous Delegate Methods *****");

            // Build the necessary Func<> delegates using anonymous methods.
            Func<string, bool> searchFilter =
                delegate (string item) { return item.Contains(" "); };

            Func<string, string> itemToProcess = delegate (string s) { return s; };

            // Pass the delegates into the methods of Enumerable.
            var subset = list
                .Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);

            // Print out the results.
            foreach (var item in subset)
                Console.WriteLine("Sorted Item: {0}", item);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Query a list of strings using explicit (or raw) delegates.
    /// Note use of IEnumerable to allow for any collection as an arg to methods.
    /// Also shows the use of static methods in a class utilizing Linq methods.
    /// </summary>
    class VeryComplexQueryExpression
    {
        public static void QueryStringsWithFuncDelegates(IEnumerable<string> list)
        {
            Console.WriteLine("***** Using LINQ Method Syntax with Raw Delegates *****");

            // Build the necessary Func<> delegates.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            // Pass the delegates into the methods of Enumerable.
            var subset = list
                .Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);

            // Print out the results.
            foreach (var item in subset)
                Console.WriteLine("Sorted Item ToUpper() in delegate target: {0}", item);
            Console.WriteLine();
        }

        // Delegate targets.
        public static bool Filter(string item)
        {
            return item.Contains(" ");
        }
        public static string ProcessItem(string item)
        {
            return item.ToUpper();
        }
    }
}
