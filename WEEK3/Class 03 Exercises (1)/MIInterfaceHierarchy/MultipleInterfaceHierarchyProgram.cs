using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInterfaceHierarchy
{
    /// <summary>
    /// Demostrates use of multiple interfaces implemented by classes.
    /// </summary>
    class MultipleInterfaceHierarchyProgram
    {
        static void Main(string[] args)
        {
            Square square = new Square();
            Rectangle rectangle = new Rectangle();
            (square as IPrintable).Draw();
            (square as IDrawable).Draw();
            // square.Draw(); // will not compile!!
            square.Print();

            rectangle.Draw();
            rectangle.Print();

            // these are both the same!
            (rectangle as IPrintable).Draw();
            (rectangle as IDrawable).Draw();

            Console.ReadLine();
        }
    }

    // Multiple inheritance for interface types is a-okay.
    interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw(); // <-- Note possible name clash here!
    }

    // Multiple interface inheritance. OK!
    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }

    class Square : IShape
    {
        // Using explicit implementation to handle member name clash.
        void IPrintable.Draw()
        {
            Console.WriteLine($"Square Drawing to Printer, number of sides {GetNumberOfSides()}");
        }
        void IDrawable.Draw()
        {
            Console.WriteLine($"Square Drawing to Screen, number of sides {GetNumberOfSides()}");
        }
        public void Print()
        {
            Console.WriteLine($"Square Printing, number of sides {GetNumberOfSides()}");
        }

        public int GetNumberOfSides()
        {
            return 4;
        }
    }

    class Rectangle : IShape
    {
        public int GetNumberOfSides()
        {
            return 4;
        }

        // not clear which interface this refers to, but ...

        public void Draw()
        {
            Console.WriteLine("Rectangle just Drawing...");
        }

        public void Print()
        {
            Console.WriteLine("Rectangle Printing...");
        }
    }

}
