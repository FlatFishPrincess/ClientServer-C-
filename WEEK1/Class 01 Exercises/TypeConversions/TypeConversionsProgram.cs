using System;
using static System.Console;

namespace TypeConversions
{
    class TypeConversionsProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with type conversions *****\n");
            short firstNumber = 30000, secondNumber = 30000;

            // Explicitly cast the int into a short (and allow loss of data).
            short answer = (short)Add(firstNumber, secondNumber);

            WriteLine("{0} + {1} = {2}",
              firstNumber, secondNumber, answer);
            NarrowingAttempt();
            ProcessBytes();
            ReadLine();
        }

        static int Add(int x, int y)
        { return x + y; }

        #region Narrowing / Widening examples
        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;

            // Explicitly cast the int into a byte (no loss of data).
            myByte = (byte)myInt;
            WriteLine("Value of myByte: {0}", myByte);
        }

        static void ProcessBytes()
        {
            byte firstByte = 100;
            byte secondByte = 250;

            // This time, tell the compiler to add CIL code
            // to throw an exception if overflow/underflow
            // takes place.
            try
            {
                byte sum = checked((byte)Add(firstByte, secondByte));
                WriteLine("sum = {0}", sum);
            }
            catch (OverflowException ex)
            {
                WriteLine(ex.Message);
            }
        }

        static void NarrowWithConvert()
        {
            byte myByte = 0;
            int myInt = 200;
            myByte = Convert.ToByte(myInt);
            WriteLine("Value of myByte: {0}", myByte);
        }
        #endregion
    }
}
