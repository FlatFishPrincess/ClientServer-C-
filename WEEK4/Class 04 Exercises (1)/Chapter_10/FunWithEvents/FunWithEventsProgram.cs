using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEvents
{
    class FunWithEventsProgram
    {
        public delegate void HandleMathEvent(int c, int x, int y);  // define a delegate

        public static event HandleMathEvent DoSomeMath;
        public static event HandleMathEvent DoSomeMoreMath;

        static void Main(string[] args)
        {
            Random rand = new Random();

            // just one handler for DoSomeMath
            DoSomeMath += Add;

            // register two handlers for DoSomeMoreMath
            // both will fire when event occurs

            DoSomeMoreMath += Subtract;
            DoSomeMoreMath += RandomAdd;
            DoSomeMoreMath += Square;

            // flip a coin, if even DoSomeMath, otherwise DoSomeMoreMath

            for (int i = 0; i < 5; i++)
            {
                int choice = rand.Next(0, 2);
                if (choice == 0)
                    DoSomeMath?.Invoke(choice, 2, 3);
                else DoSomeMoreMath?.Invoke(choice, 10, 7);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// show the choice and add the next two arguments and display
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Add(int choice, int x, int y)
        {
            Console.WriteLine("Flip {3} Add: {0} + {1} = {2}", x, y, x + y, choice);
        }

        public static void Subtract(int c, int x, int y)
        {
            Console.WriteLine("Flip {3} Subtract: {0} + {1} = {2}", x, y, x - y, c);
        }

        public static void RandomAdd(int c, int x, int y)
        {
            Console.WriteLine("Flip {3} RandomAdd: {0} + {1} = {2}", x, y, x + y + c, c);
        }

        public static void Square(int choice, int x, int y)
        {
            Console.WriteLine($"Flip {choice} Square of {x}: {x * x}, {y} ignored");
        }
    }
}
