using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEvents
{
    class Program
    {
        public delegate void HandleMathEvent(int c, int x, int y);
        public static event HandleMathEvent DoSomeMath;
        public static event HandleMathEvent DoSomeMoreMath;

        static void Main(string[] args)
        {
            Random rand = new Random();

            // just one handler for DoSomeMMath
            DoSomeMath += Add;

            // register two handlers for DoSomeMoreMath
            // both will fire when event occurs

            DoSomeMoreMath += Subtract;
            DoSomeMoreMath += RandomAdd;

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

        public static void Add(int c, int x, int y)
        {
            Console.WriteLine("Flip {3} Add: {0} + {1} = {2}", x, y, x + y, c);
        }

        public static void Subtract(int c, int x, int y)
        {
            Console.WriteLine("Flip {3} Subtract: {0} + {1} = {2}", x, y, x - y, c);
        }

        public static void RandomAdd(int c, int x, int y)
        {
            Console.WriteLine("Flip {3} RandomAdd: {0} + {1} = {2}", x, y, x + y + c, c);
        }
    }
}
