using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class CustomInterfacesProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interfaces *****\n");

            // Make an array of Shapes.
            Shape[] shapes = {
                new Hexagon("Hexy", ConsoleColor.Red),
                new Circle(),
                new Sphere("Ball"),
                new Triangle("Joe", ConsoleColor.Cyan),
                new Circle("JoJo"),
                // new Knife() -- Won't compile, is not a Shape!
            };

            IPointy[] pointyObjects = {
                new Hexagon("Hexy", ConsoleColor.Red), 
                new Triangle("Joe", ConsoleColor.Cyan),
                new PitchFork(),
                new Knife()
                // new Sphere("Earth") -- Won't compile! Is not Pointy!
            };

            // Get first pointy item.
            // To be safe, you'd want to check firstPointyShape for null before proceeding.
            IPointy firstPointyShape = FindFirstPointyShape(shapes);
            Console.WriteLine("First point item in Shapes array has {0} points", firstPointyShape.Points);

            Console.WriteLine("\nShow all Shapes\n");

            for (int i = 0; i < shapes.Length; i++)
            {
                // Recall the Shape base class defines an abstract Draw()
                // member, so all shapes know how to draw themselves.
                shapes[i].Draw();

                // is this shape pointy? Then set it to an IPointy object.

                if (shapes[i] is IPointy)
                {
                    IPointy ip = shapes[i] as IPointy;
                    Console.WriteLine("->{0} Points: {1} Color: {2}", ip.Description, ip.Points, ip.Color);
                }
                else
                    // If this is a sphere, the description will not display!
                    Console.WriteLine("-> {0} is not pointy!", shapes[i].Description);
                Console.WriteLine();

                // Can I draw you in 3D?
                if (shapes[i] is IDraw3D)
                    DrawIn3D(shapes[i] as IDraw3D);

            }
            Console.WriteLine("\nShow Pointy Objects\n");

            foreach(IPointy p in pointyObjects)
            {
                Console.WriteLine($"{p.Description} points {p.Points} color {p.Color}");
            }
            Console.ReadLine();
        }

        // I'll draw anyone supporting IDraw3D.
        static void DrawIn3D(IDraw3D interface3d)
        {
            Console.Write("-> Drawing IDraw3D compatible type: ");
            interface3d.Draw3D();
        }

        // This method returns the first object in the
        // array that implements IPointy.
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                if (s is IPointy)
                    return s as IPointy;
            }
            return null;
        }
    }
}
