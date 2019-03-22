using System;
using System.Linq;

namespace ImplicitlyTypedLocalVars
{
    class ImplicitlyTypedLocalVarsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Implicit Typing *****");
            DeclareImplicitVars();
            Console.ReadLine();

            QueryOverInts();
            Console.WriteLine();
            Console.ReadKey();
        }

        #region Implicit data typing
        /// <summary>
        /// shows the use of implicit data typing
        /// </summary>
        static void DeclareImplicitVars()
        {
            // Implicitly typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            // Print out the underlying type.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);
        }

        /// <summary>
        /// This is a silly example that shows a var object returned as an int. 
        /// </summary>
        /// <returns></returns>
        static int GetAnInt()
        {
            var retVal = 9; // change this to a string and it won't compile!
            return retVal;
        }

        /// <summary>
        /// Shows that the compiler does enforce type consistency even when var is used
        /// </summary>
        static void ImplicitTypingIsStrongTyping()
        {
            // The compiler knows "s" is a System.String.
            var s = "This variable can only hold string data!";
            s = "This is fine...";

            // Can invoke any member of the underlying type.
            string upper = s.ToUpper();

            // Error! Can't assign numerical data to a a string!
            // s = 44;
        }
        #endregion

        #region LINQ example

        /// <summary>
        /// This is an advanced example of implicitly typed variables using var.
        /// LINQ can query collections, and we sometimes don't know the type of collection returned,
        /// so var comes in handy.
        /// </summary>
        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subset = from i in numbers
                         where i < 10
                         select i;

            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            // Hmm...what type is subset?
            Console.WriteLine("subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("subset is defined in: {0}", subset.GetType().Namespace);
        }
        #endregion

    }

    #region Bad use of var!
    // Uncomment to see compile errors.
    //class ThisWillNeverCompile
    //{
    //    // Error! var cannot be used as field data!
    //    private var myInt = 10;

    //    // Error! var cannot be used as a return value
    //    // or parameter type!
    //    public var MyMethod(var x, var y) { var myInt = 10; }
    //}
    #endregion
}
