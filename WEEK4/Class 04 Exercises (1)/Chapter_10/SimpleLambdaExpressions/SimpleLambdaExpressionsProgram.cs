using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class SimpleLambdaExpressionsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\nList of Integers: ");

            // Make a list of integers.
            List<int> listOfNumbers = new List<int>() { 20, 1, 4, 8, 9, 44 };
            // listOfNumbers.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            listOfNumbers.ForEach(i => Console.Write(i + " ")); // demo use of lambda in ForEach method
            Console.WriteLine();

            // Each method below finds even numbers (except for SimpleLambdaExpression)

            FindingEvenNumbersUsingDelegate(listOfNumbers);

            FindingEvenNumbersUsingAnonymousMethod(listOfNumbers);

            SimpleLambdaExpression();

            FindingEvenNumbersUsingLambdas(listOfNumbers);
            Console.ReadLine();
        }

        static void FindingEvenNumbersUsingDelegate(List<int> list)
        {

            // Call FindAll() using traditional delegate syntax.
            // Predicate<int> is needed for FindAll() argument 
            //  function is handed element of the list, and returns true or false

            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            // this works as well
            // List<int> evenNumbers = list.FindAll(IsEvenNumber);

            // This won't work, as FindAll needs System.Predicate ... even tho it matches
            CallBackTest callback2 = IsEvenNumber;
            //List<int> evenNumbers2 = list.FindAll(callback2); 

            DisplayNumberList(evenNumbers, "FindingEvenNumbersUsingDelegate, even numbers:");
        }

        delegate bool CallBackTest(int x);

        // Target for the Predicate<> delegate.
        static bool IsEvenNumber( int i)
        {
            // Is it an even number?
            return (i % 2) == 0;
        }

        static void FindingEvenNumbersUsingAnonymousMethod(List<int> list)
        {

            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(
                delegate( int i )
                {
                    return (i % 2) == 0;
                }
            );

            DisplayNumberList(evenNumbers, "FindingEvenNumbersUsingAnonymousMethod, even numbers:");
        }

        public delegate int BinaryOp(int x, int y);
        static int Add(int x, int y) => x + y;
        static void PrintSum(int x, int y) 
            => Console.WriteLine("PrintSum: lambda with WriteLine: {0} + {1} = {2}", x, y, x + y);

        /// <summary>
        /// Add two numbers together using lambda expression and a delegate that corresponds
        /// </summary>
        static void SimpleLambdaExpression()
        {
            Console.WriteLine("Simple Lambda Expression()");

            BinaryOp addThese = (x, y) => (x + y);  // lambda corresponds to anonymous function
            Console.WriteLine("addThese BinaryOp lambda: {0} + {1} = {2}", 2, 3, addThese(2,3));

            addThese = (x, y) => ((100 * x) + y);   // change to multiply first operand by 100
            Console.WriteLine("addThese BinaryOp lambda 100*x + y: {0} + {1} = {2}", 2, 3, addThese(2, 3));

            // now show normal Add lambda

            Console.WriteLine("Add lambda: {0} + {1} = {2}", 2, 3, Add(2, 3));


            // Print lambda rolls operation and WriteLine together

            PrintSum(2, 3);

        }

        static void FindingEvenNumbersUsingLambdas(List<int> list)
        {

            // Now process each argument within a group of
            // code statements.

            Console.WriteLine("FindingEvenNumbersUsingLambdas: listing all numbers in FindAll lambda");

            // argument to FindAll is a boolean that is the result of a matching function (predicate)

            List<int> numbers = list.FindAll((i) =>
            {
                Console.Write($"{i} ");
                return ((i % 2) == 0);
            });

            Console.WriteLine();

            DisplayNumberList(numbers, "FindingEvenNumbersUsingLambdas, even numbers:");

            int x = numbers.FindIndex(i => i == 8); // silly, could use numbers[8] :-)
            Console.WriteLine("index of 8 is {0}", x);

            // Example using LINQ. Note LINQ primitives/methods can use lambda args (predicates)

            var selection = list
                .Where(i => i > 4)
                .OrderBy(i => i).ToList();

            DisplayNumberList(selection, "FindingEvenNumbersUsingLambdas, sorted numbers greater than 4:");

        }

        /// <summary>
        /// Display a list of numbers
        /// </summary>
        /// <param name="numberList">List<int> containing number list</int></param>
        /// <param name="message">Optional header message</param>
        static void DisplayNumberList(List<int> numberList, string message = "")
        {
            Console.WriteLine(message);

            foreach (int i in numberList)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

        }

    }
}
