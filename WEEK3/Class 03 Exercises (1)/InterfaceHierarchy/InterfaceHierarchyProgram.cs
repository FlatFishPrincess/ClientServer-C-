using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy
{
    /// <summary>
    /// Interfaces can be in a hierarchy (like classes).
    /// Simple example using fake drawing methods.
    /// </summary>
    class InterfaceHierarchyProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Interface Hierarchy *****");

            // Call from object level.
            Console.WriteLine("Using bitmap uses IAdvancedDrawable implements IDrawable");
            BitmapImage bitmap = new BitmapImage();
            bitmap.Draw();
            bitmap.DrawInBoundingBox(10, 10, 100, 150);
            bitmap.DrawUpsideDown();

            // Call as IDrawable
            Console.WriteLine("Using drawableItem = bitmap as IDrawable");
            IDrawable drawableItem = bitmap as IDrawable;
            drawableItem.Draw();

            // Call as IAdvancedDrawable
            Console.WriteLine("Using advancedDrawableItem = bitmap as IAdvancedDrawable");
            IAdvancedDrawable advancedDrawableItem = bitmap as IAdvancedDrawable;
            advancedDrawableItem.DrawUpsideDown();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Base interface for drawing
    /// </summary>
    public interface IDrawable
    {
        void Draw();
    }
    /// <summary>
    /// Adds other interface methods
    /// </summary>
    public interface IAdvancedDrawable : IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    /// <summary>
    /// Implements IAdvancedDrawable, which also implies implements IDrawable
    /// </summary>
    public class BitmapImage : IAdvancedDrawable
    {
        public void Draw()
        {
            Console.WriteLine("Drawing()");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine($"DrawingInBoundingBox({top}, {left}, {bottom}, {right})");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("DrawUpsideDown()");
        }
    }
}
