using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithStrings
{
    class FunWithStringsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Strings *****\n");
            BasicStringFunctionality();
            Console.ReadLine();

            StringConcatenation();
            Console.ReadLine();

            EscapeChars();
            Console.ReadLine();

            StringsAreImmutable();
            Console.ReadLine();

            FunWithStringBuilder();
            Console.ReadLine();

            StringInterpolation();
            Console.ReadLine();
        }

        #region String basics
        /// <summary>
        /// shows basic string methods and properties
        /// </summary>
        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}",
              firstName.Contains("y"));
            Console.WriteLine("New first name: {0}", firstName.Replace("dy", ""));
            Console.WriteLine();
        }
        #endregion

        #region Concatenation
        /// <summary>
        /// shows string concatenation
        /// </summary>
        static void StringConcatenation()
        {
            Console.WriteLine("=> String concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2;
            Console.WriteLine(s3);
            Console.WriteLine();
        }
        #endregion

        #region Escape Chars
        /// <summary>
        /// shows how to use escape characters in strings
        /// </summary>
        static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a ";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Everyone loves \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");

            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");
            Console.WriteLine();

            // The following string is printed verbatim
            // thus, all escape characters are displayed.
            Console.WriteLine(@"C:\MyApp\bin\Debug");

            // White space is preserved with verbatim strings.
            string myLongString = @"This is a very
                 very
                      very
                           long string";
            Console.WriteLine(myLongString);
            Console.WriteLine();
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");
        }
        #endregion

        #region Immutable test

        /// <summary>
        /// shows how strings are immutable (not able to be changed). 
        /// Strings constants are stored on the heap, but references to them are on the stack.
        /// </summary>
        static void StringsAreImmutable()
        {
            Console.WriteLine("=> Strings are immutable:");

            //// Set initial string value.
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);

            //// Uppercase s1?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);

            //// Nope! s1 is in the same format!
            Console.WriteLine("s1 = {0}", s1);

            string s2 = "My other string";
            // s2[1] = 'c';

            char c = s2[1]; // this is ok!

            s2 = "New string value";
            Console.WriteLine(s2);
        }
        #endregion

        #region StringBuilder
        /// <summary>
        /// shows how to modify a string - use the StringBuilder class instead!
        /// This will be needed in the lab for this class.
        /// </summary>
        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");

            // Make a StringBuilder with an initial size of 256.
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****", 256);

            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Beyond Good and Evil");
            sb.AppendLine("Deus Ex 2");
            sb.AppendLine("System Shock");
            sb.AppendFormat("{0,-10} {1}\n", "1.", "Walking Dead");
            Console.WriteLine(sb);

            sb.Replace("2", "Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }
        #endregion

        #region String interpolation
        /// <summary>
        /// String interpolation is used very frequently, and is a nice feature of C#
        /// When $ is placed in front of a string, variables can be put inside of curly braces {}
        ///  and their value is formatted.
        /// </summary>
        static void StringInterpolation()
        {
            Console.WriteLine("=> String Interpolation:");

            // Some local variables we will plug into our larger string
            int age = 4;
            string name = "Soren";

            // Using curly bracket syntax.
            string greeting = string.Format("\tHello {0} you are {1} years old.", 
                name.ToUpper(), age);
            Console.WriteLine(greeting);

            // Using string interpolation
            string greeting2 = $"\tHello {name.ToUpper()} you are {age} years old.";
            Console.WriteLine(greeting2);
        }
        #endregion
    }
}
