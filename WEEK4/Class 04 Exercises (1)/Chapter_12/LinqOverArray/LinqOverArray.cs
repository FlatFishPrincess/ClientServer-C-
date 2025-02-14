﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class LinqOverArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            QueryOverStrings();
            Console.WriteLine();

            QueryOverStringsLongHand();
            Console.WriteLine();

            QueryOverInts();
            Console.WriteLine();

            QueryOverIntsImmediate();
            Console.WriteLine();



            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            Console.WriteLine("***** QueryOverStrings - games with spaces *****");

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            ReflectOverQueryResults(subset);

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Sorted Item: {0}", s);

        }

        static void QueryOverStringsLongHand()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            Console.WriteLine("***** QueryOverStringsLongHand - LINQ not used*****");

            string[] gamesWithSpaces = new string[5];

            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }

            // Now sort them.
            Array.Sort(gamesWithSpaces);
            ReflectOverQueryResults(gamesWithSpaces);

            // Print out the results.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Sorted Item: {0}", s);
            }
            Console.WriteLine();

        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            Console.WriteLine("***** QueryOverInts - < 10 then first element changed *****");


            // Get numbers less than ten.
            var subset = from i in numbers
                         where i < 10
                         select i;

            // LINQ statement evaluated here!
            foreach (var i in subset)
                Console.WriteLine("{0} < 10", i);
            Console.WriteLine();

            // Change some data in the array.
            numbers[0] = 4;
            ReflectOverQueryResults(subset);
            // Evaluated again!
            foreach (var j in subset)
                Console.WriteLine("First element changed: {0} < 10", j);

            Console.WriteLine();
        }

        static void QueryOverIntsImmediate()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            Console.WriteLine("***** QueryOverStringsImmediate - < 10 and first element changed, but immediate *****");


            // Get data RIGHT NOW as int[].
            int[] subsetAsIntArray =
              (from i in numbers where i < 10 select i).ToArray<int>();

            foreach(int i in subsetAsIntArray)
                Console.WriteLine("{0} < 10", i);

            // Get data RIGHT NOW as List<int>.
            List<int> subsetAsListOfInts =
              (from i in numbers where i < 10 select i).ToList<int>();

            numbers[0] = 4;

            foreach (int i in subsetAsListOfInts)
                Console.WriteLine("First element changed in numbers: {0} < 10", i);
        }

        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("***** Info about your query *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}",
              resultSet.GetType().Assembly.GetName().Name);
        }
    }
}
