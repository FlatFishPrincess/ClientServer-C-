using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCar;

namespace CustomEnumerator
{
    class CustomEnumeratorProgram
    {
        /// <summary>
        /// Display all of the Cars in the garage, and their current speed.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();

            // This uses the Garage enumerator, which is simply the enumerator for 
            // the internal array of Cars

            foreach (Car c in carLot)
            {
                Console.WriteLine(c);
            }
            Console.ReadLine();
        }
    }
}
