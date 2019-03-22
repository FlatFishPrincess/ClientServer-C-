using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint
{
    class GenericPointProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Generic Structures *****\n");

            // Point using ints.
            Point<int> point = new Point<int>(10, 10);
            Console.WriteLine(point);
            point.ResetPoint();
            Console.WriteLine(point);
            Console.WriteLine();

            // Point using double.
            Point<double> point2 = new Point<double>(5.4, 3.3);
            Console.WriteLine(point2);
            point2.ResetPoint();
            Console.WriteLine(point2);

            // Point using AxisLocation class

            AxisLocation x = new AxisLocation() { Location = 20, Color = ConsoleColor.Red, Name = "X" };
            AxisLocation y = new AxisLocation() { Location = 30, Color = ConsoleColor.Black, Name = "Y" };

            Point<AxisLocation> point3 = new Point<AxisLocation>(x, y);
            Console.WriteLine(point3);
            point3.ResetPoint();
            Console.WriteLine(point3);

            Console.ReadLine();
        }
    }
}
