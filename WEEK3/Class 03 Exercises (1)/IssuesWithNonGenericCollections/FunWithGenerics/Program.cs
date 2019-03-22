using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init a standard array.
            int[] myArrayOfInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Init a generic List<> of ints.
            List<int> myGenericList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Init an ArrayList with numerical data.
            ArrayList myList = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int el = 1;
            Console.WriteLine("Element {3} std {0} list {1} arraylist {2}",
                myArrayOfInts[el], myGenericList[el], myList[el], el);

            Console.ReadLine();
        }
    }
}
