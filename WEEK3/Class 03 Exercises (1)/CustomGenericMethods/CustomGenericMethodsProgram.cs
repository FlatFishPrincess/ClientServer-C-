using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class CustomGenericMethodsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Generic Methods *****\n");

            // Swap 2 ints.
            // no parameters for DisplayBaseClass(), so no signature, so need to provide type T
            MyGenericMethods.DisplayBaseClass<int>(); 
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            MyGenericMethods.Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: {0}, {1}", a, b);

            Console.WriteLine();

            // Swap 2 strings.
            MyGenericMethods.DisplayBaseClass<string>();
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0} {1}", s1, s2);
            MyGenericMethods.Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0} {1}", s1, s2);
            Console.WriteLine();

            // Compiler will infer System.Boolean from signature
            MyGenericMethods.DisplayBaseClass<bool>();
            bool b1 = true, b2 = false;
            Console.WriteLine("Before swap: {0}, {1}", b1, b2);
            MyGenericMethods.Swap(ref b1, ref b2);
            Console.WriteLine("After swap: {0}, {1}", b1, b2);
 
            Console.WriteLine();

            Person p1 = new Person() { FirstName = "John", LastName = "Doe", Age = 21 };
            Person p2 = new Person() { FirstName = "Sven", LastName = "Klepsch", Age = 15 };

            MyGenericMethods.DisplayBaseClass<Person>();
            Console.WriteLine("Before swap: {0}, {1}", p1, p2);
            MyGenericMethods.Swap(ref p1, ref p2);
            Console.WriteLine("After swap: {0}, {1}", p1, p2);
            Console.WriteLine();

            Console.ReadLine();
        }

        #region Non-Generic swap methods.
        // Swap two integers.
        static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        // Swap two Person objects.
        static void Swap(ref Person a, ref Person b)
        {
            Person temp;
            temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }

    /// <summary>
    /// Swap and DisplayBaseClass generic methods
    /// Note that both are static. 
    /// This is therefore a utility class.
    /// </summary>

    public static class MyGenericMethods
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}",
                typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base class of {0} is: {1}.",
                typeof(T), typeof(T).BaseType);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }
    }
}
