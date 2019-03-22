using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class CloneablePointProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Cloning *****\n");
            Console.WriteLine("Cloned startingPoint and stored new Point in clonedPoint");
            Point startingPoint = new Point(100, 100, "Jane");
            Point clonedPoint = (Point)startingPoint.Clone();

            Console.WriteLine("Before modification:");
            Console.WriteLine($"startingPoint: {startingPoint}");
            Console.WriteLine($"clonedPoint: {clonedPoint}");

            // now change clonedPoint

            clonedPoint.desc.PointName = "My new Point";
            clonedPoint.X = 9;

            Console.WriteLine("\nChanged clonedPoint.desc.PointName and clonedPoint.X");
            Console.WriteLine("After modification:");
            Console.WriteLine($"startingPoint: {startingPoint}");
            Console.WriteLine($"clonedPoint: {clonedPoint}");

            Console.ReadLine();
        }
    }
}
