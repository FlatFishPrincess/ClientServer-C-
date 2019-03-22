using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class LinqReturnValuesProgram
    {
        // demonstrates that linq expressions default to returning IEnumerable<T> 

        static void Main(string[] args)
        {
            string[] colors = {"Light Red", "Green",
                "Yellow", "Dark Red", "Red", "Purple", "Sea Green"};

            Console.WriteLine("All colors:");
            foreach (string item in colors)
                Console.WriteLine(item);

            Console.WriteLine("\nGreen colors from LINQ Contains:");
            IEnumerable<string> subset = GetGreenColorsSubset(colors);
            foreach (string item in subset)
                Console.WriteLine(item);

            Console.WriteLine("\nRed colors from LINQ Contains but ToArray():");

            string[] arraySubset = GetRedColorsSubsetAsArray(colors);

            foreach (string item in arraySubset)
                Console.WriteLine(item);

            Console.ReadLine();
        }

        static IEnumerable<string> GetGreenColorsSubset(string[] colors)
        {
            // Note subset is an IEnumerable<string>-compatible object.
            //IEnumerable<string> theRedColors = from c in colors
            //                                   where c.Contains("Green")
            //                                   select c;

            // note var is set to IEnumerable<string>, LINQ returns this as default
            var theRedColors = from c in colors
                               where c.Contains("Green")
                               select c;

            return theRedColors;
        }

        static string[] GetRedColorsSubsetAsArray(string[] colors)
        {
            var theRedColors = from c in colors
                               where c.Contains("Red")
                               select c;

            // Map results into an array, as string[] is not IEnumerable
            return theRedColors.ToArray();
        }
    }
}
