using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    /// <summary>
    /// The abstract base class of the hierarchy. 
    /// All shapes have a name and color.
    /// </summary>
    abstract class Shape
    {
        public Shape(string name = "NoName", ConsoleColor color = ConsoleColor.Black)
        {
            Description = name;
            Color = color;
        }

        public string Description { get; set; }
        public ConsoleColor Color { get; set; }

        // Force all child classes to define how to be rendered.
        public abstract void Draw();
    }

    /// <summary>
    /// Circle derives from Shape, but is not pointy or 3d!
    /// </summary>
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", Description);
        }
    }
 
    /// <summary>
    /// Hexagon is derived from Shape, but implements IPointy and IDraw3d interfaces
    /// </summary>
    class Hexagon : Shape, IPointy
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public Hexagon(string name, ConsoleColor color) : base(name, color) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", Description);
        }
        // IPointy implementation.
        public byte Points
        {
            get { return 6; }
        }

        // public ConsoleColor Color { get; set; }

        public void Draw3D()
        { Console.WriteLine("Drawing Hexagon in 3D!"); }
    }

    /// <summary>
    /// Sphere derives from Circle (which derives from Shape)
    ///     Is 3d, so implements IDraw3d, but is NOT pointy
    /// As an example, hide name property and draw method.
    /// </summary>

    class Sphere : Circle, IDraw3D
    {
        // Hide the ShapeName property above me.
        public new string Description { get; set; }

        public Sphere(string name)
        {
            Description = name;
            // base.Description = this.Description; // but what the heck, save it anyway :-)
        }

        // Hide any Draw() implementation above me in parents
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Sphere", Description);
        }
        public void Draw3D()
        {
            Console.WriteLine("Drawing Sphere in 3D!");
        }
    }

    // New Shape derived class named Triangle.
    // notice color and description required by IPointy are in Shape

    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public Triangle(string name, ConsoleColor color) : base(name, color) { }
        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle", Description);
        }

        // IPointy implementation.
        public byte Points
        {
            get { return 3; }
        }

        // public ConsoleColor Color { get; set;  }
    }

}
