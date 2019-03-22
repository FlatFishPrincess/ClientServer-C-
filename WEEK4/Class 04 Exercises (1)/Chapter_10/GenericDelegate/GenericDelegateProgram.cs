using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GenericDelegate
{
    // This generic delegate can call any method
    // returning void and taking a single type parameter.

    public delegate void MyGenericDelegate<T>( T arg );

    class GenericDelegateProgram
    {
        static void Main( string[] args )
        {
            WriteLine("***** Generic Delegates *****\n");

            // Register targets. 
            // Note how the arg to MyGenericDelegate constructor is a function.

            MyGenericDelegate<string> stringFunction =
              new MyGenericDelegate<string>(MakeUpperCase);

            MyGenericDelegate<string> strFunction = new MyGenericDelegate<string>(ConcateString);

            strFunction("Hell0");
            stringFunction("Some string data");

            stringFunction = new MyGenericDelegate<string>(MakeLowerCase);
            stringFunction("SOME MORE string DATA");


            MyGenericDelegate<int> integerFunction =
              new MyGenericDelegate<int>(IncrementInteger);

            integerFunction(9);

            integerFunction = new MyGenericDelegate<int>(DecrementInteger);
            integerFunction(201);

            Console.ReadLine();
        }

       static void ConcateString(string arg)
        {
            Console.WriteLine(arg + arg);
        }


        static void MakeUpperCase( string arg )
        {
            WriteLine($"MakeUpperCase: arg in uppercase is: {arg.ToUpper()}");
        }

        static void MakeLowerCase(string arg)
        {
            WriteLine($"MakeLowerCasee: arg in lowercase is: {arg.ToLower()}");
        }
        static void IncrementInteger( int arg )
        {
            WriteLine($"IncrementInteger: {arg}++ is: {++arg}");
        }

        static void DecrementInteger(int arg)
        {
            WriteLine($"DecrementInteger: {arg}-- is: {--arg}");
        }
    }
}

