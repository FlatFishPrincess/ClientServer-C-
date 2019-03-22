using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpAppWithArguments
{
    class SimpleCSharpAppWithArgumentsProgram
    {
        static void Main(string[] args)
        {
            // See Properties->Debug for setting arguments
            Console.WriteLine("Hello World");
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine(args[i]);

            Console.ReadLine();
        }
    }
}
