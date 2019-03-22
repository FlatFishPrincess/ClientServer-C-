using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    // This delegate can point to any method,
    // taking two integers and returning an integer.
    // think of this as a template or recipe for a function

    public delegate int BinaryOp(int x, int y);
    public delegate int UnaryOp(int x);

    // This class contains simple math methods the delegates above will
    // point to.
    public class SimpleMathOperators
    {
        public int Add(int x, int y)
        { return x + y; }
        public int Subtract(int x, int y)
        { return x - y; }
        public int SquareNumber(int a)
        { return a * a; }
    }

    // A few more math methods

    public class OtherMathOperators
    {
        /// <summary>
        /// The difference between the squares of two numbers
        /// </summary>
        /// <param name="x">First number to be squared</param>
        /// <param name="y">Second number to be squared</param>
        /// <returns></returns>
        public int DifferenceBetweenSquares(int x, int y)
        {
            return ((x * x) - (y * y));
        }

        /// <summary>
        /// Recursive factorial function
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Factorial(int x)
        {
            if (x == 1)
                return x;
            else
            {
                return Factorial(x - 1) * x;
            }
        }

        public int SumOfSeries(int x)
        {
            return ((x) * (x + 1)) / 2;
        }
    }

    class SimpleDelegateProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            const int operand1 = 5;
            const int operand2 = 12;

            Console.WriteLine($"operand1 is {operand1}, operand2 is {operand2}");

            // create operators classes to be used to assign to delegates
            // note the methods of each class are unary or binary

            SimpleMathOperators simpleMathOps = new SimpleMathOperators();
            OtherMathOperators anotherMathOp = new OtherMathOperators();

            // Create a BinaryOp delegate object that
            // "points to" SimpleMathOperators.Add().

            BinaryOp addTheseTogether = new BinaryOp(simpleMathOps.Add);
            DisplayDelegateInfo(addTheseTogether);

            // Invoke Add() method indirectly using delegate object.

            Console.WriteLine($"Add: {operand1} and {operand2} is {addTheseTogether(operand1, operand2)}");

            // now do the same for each unary or binary method in the classes

            UnaryOp squareOf = new UnaryOp(simpleMathOps.SquareNumber);

            DisplayDelegateInfo(squareOf);

            Console.WriteLine($"SquareNumber: {operand1} squared is {squareOf(operand1)}");

            BinaryOp differenceOfSquaresOf = new BinaryOp(anotherMathOp.DifferenceBetweenSquares);

            DisplayDelegateInfo(differenceOfSquaresOf);

            Console.WriteLine($"DifferenceBetweenSquares: {operand1} squared minus {operand2} squared is {differenceOfSquaresOf(operand1, operand2)}");

            UnaryOp factorialOf = new UnaryOp(anotherMathOp.Factorial);

            DisplayDelegateInfo(factorialOf);

            Console.WriteLine($"Factorial: factorial of {operand1} is {factorialOf(operand1)}");

            UnaryOp seriesSum = new UnaryOp(anotherMathOp.SumOfSeries);

            DisplayDelegateInfo(seriesSum);

            Console.WriteLine($"SeriesSum: sum of series of {operand1} is {seriesSum(operand1)}");

            Console.ReadLine();
        }

        /// <summary>
        /// Display the names of each member of the delegate's invocation list
        /// </summary>
        /// <param name="delObj">delegate</param>
        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }
    }
}

