using System;

namespace ICloneableExample
{
    class ICloneableExampleProgram 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Interfaces *****\n");

            // string class supports the ICloneable interface.
            string myStr = "Hello";

            // Get info about a unix operating system, implements ICloneable interface

            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());

            // set up a new connection to a SQL database
            // SQLConnection implements ICloneable interface
            System.Data.SqlClient.SqlConnection sqlCnn =
                new System.Data.SqlClient.SqlConnection();

            // all of the above objects can be passed into method taking ICloneable.
            CloneMe(myStr); 
            CloneMe(unixOS);
            CloneMe(sqlCnn);

            // now clone unixOS and display
            OperatingSystem osClone = ReturnAClone(unixOS) as OperatingSystem;
            Console.WriteLine($"osClone: {osClone.GetType().Name} {osClone.GetHashCode()}" +
                $", original is {unixOS.GetType().Name} {unixOS.GetHashCode()}");
            Console.ReadLine();
        }

        /// <summary>
        /// Clone an object that implements ICloneable and display information about the cloned object
        /// </summary>
        /// <param name="c">object to be cloned</param>
        private static void CloneMe(ICloneable c)
        {
            // Clone whatever we get and print out the name.
            object theClone = c.Clone();
            Console.WriteLine($"Your clone is a: {theClone.GetType().Name} {theClone.GetHashCode()}, " +
                $"original is {c.GetType().Name} {c.GetHashCode()}");
        }

        private static ICloneable ReturnAClone(ICloneable c)
        {
            return (ICloneable)c.Clone();
        }
    }
}