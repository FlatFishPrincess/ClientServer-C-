using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    // The Point now supports "clone-ability."
    public class Point : ICloneable
    {
        // Coordinates

        public int X { get; set; }
        public int Y { get; set; }

        // information about the point (name, ...)

        public PointDescription desc = new PointDescription();

        public Point(int xPos, int yPos, string pointName)
        {
            X = xPos;
            Y = yPos;
            desc.PointName = pointName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public Point() { }

        // Override Object.ToString().
        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, Name = {desc.PointName}, ID = {desc.PointID}";
        }

        // Return a copy of the current object.
        // Now we need to adjust for the PointDescription member.
        public object Clone()
        {
            // First get a shallow copy.
            Point newPoint = (Point)this.MemberwiseClone();

            // Then fill in the gaps.
            // COMMENT THIS OUT TO SHOW SHALLOW COPY EXAMPLE

            PointDescription currentDesc = new PointDescription
            {
                PointName = this.desc.PointName
            };
            newPoint.desc = currentDesc;
            return newPoint;
        }

    }

    // This class describes a point.
    public class PointDescription
    {
        public string PointName { get; set; }
        public Guid PointID { get; set; } // object GUID from System

        public PointDescription()
        {
            PointName = "No-name";
            PointID = Guid.NewGuid(); // ensure ID is unique
        }
    }

}
