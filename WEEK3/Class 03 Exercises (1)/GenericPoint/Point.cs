using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint
{
    /// <summary>
    /// Point class using generic type T
    /// </summary>
    /// <typeparam name="T">Type of point</typeparam>
    public class Point<T>
    {
        // Generic properties 
        public T X { get; set; }
        public T Y { get; set; }

        // Generic constructor.
        public Point(T xVal, T yVal)
        {
            X = xVal;
            Y = yVal;
        }

        public override string ToString()
        {
            // Format plays nice if args are null

            return $"Point coordinate [{X}, {Y}]";
        }

        /// <summary>
        /// Reset fields to default values. If ref, sets to null
        /// </summary>
        public void ResetPoint()
        {
            X = default(T);
            Y = default(T);
        }
    }
    /// <summary>
    /// Example class for location of one axis of a point.
    /// Could be used for multidimensional point.
    /// location is in axis direction, color and name are example properties.
    /// </summary>
    public class AxisLocation
    {
        public int Location { get; set; } 
        public ConsoleColor Color { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"(axis location: {Location} color: {Color} name: {Name})";
        }
    }
}
