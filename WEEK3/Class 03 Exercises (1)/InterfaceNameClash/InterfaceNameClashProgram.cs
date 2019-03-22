using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class InterfaceNameClashProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Interface Name Clashes *****\n");
            Octagon octagon = new Octagon("Octagon");
            Circle circle = new Circle("Circle");

            // We now must use casting to access the Draw()
            // members.
            IDrawToForm drawToForm = (IDrawToForm)octagon;
            drawToForm.Draw();

            drawToForm = (IDrawToForm)circle;
            drawToForm.Draw();

            // Shorthand notation if you don't need
            // the interface variable for later use.
            ((IDrawToPrinter)octagon).Draw();

            // Will draw twice just to show use of as keyword
            if (octagon is IDrawToMemory)
            {
                ((IDrawToMemory)octagon).Draw();
                (octagon as IDrawToMemory).Draw();
            }

            Console.ReadLine();
        }
    }
    // interfaces below are examples of requirements to 
    // draw to different devices. The user can then
    // implement each for a specific device: a form,
    // video memory, or a printer.

    /// <summary>
    /// Fake draw to a form
    /// </summary>
    public interface IDrawToForm
    {
        string Description { get; set; }
        void Draw();
    }

    /// <summary>
    /// Fake draw to video frame buffer
    /// </summary>
    public interface IDrawToMemory
    {
        string Description { get; set; }
        void Draw();
    }

    /// <summary>
    /// Fake draw to printer
    /// </summary>
    public interface IDrawToPrinter
    {
        string Description { get; set; }
        void Draw();
    }

    /// <summary>
    /// Class which implements multiple interfaces. 
    /// Note that a child class cannot be built from multiple parents in C#!
    /// Only interfaces work this way.
    /// </summary>
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        public Octagon(string name)
        {
            Description = name;
        }
        // only need one property implementation!

        public string Description { get; set; }

        // Explicitly bind Draw() method implementations
        // to a given interface. Need them all!

        void IDrawToForm.Draw()
        {
            Console.WriteLine($"{Description}: Drawing to form...");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine($"{Description}: Drawing to memory...");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine($"{Description}: Drawing to a printer...");
        }
    }

    class Circle : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        public Circle(string name)
        {
            Description = name;
        }
        // only need one property implementation!

        public string Description { get; set; }

        // For this class, just implement Draw, but it is unclear which one is intended!!

        public void Draw()
        {
            Console.WriteLine($"{Description}: Drawing to form...");
        }
 
       
    }
}
