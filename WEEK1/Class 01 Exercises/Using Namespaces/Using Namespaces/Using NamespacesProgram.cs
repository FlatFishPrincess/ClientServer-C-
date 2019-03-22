using System;
// using System.IO;

namespace Using_Namespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string lines = System.IO.File.ReadAllText(@"..\..\testfile.txt");
            // string lines = File.ReadAllText(@"..\..\testfile.txt");

            Console.WriteLine(lines);
            Console.ReadLine();
        }
    }
}
