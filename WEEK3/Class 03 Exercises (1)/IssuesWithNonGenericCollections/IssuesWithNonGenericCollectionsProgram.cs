using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace IssuesWithNonGenericCollections
{
    class IssuesWithNonGenericCollectionsProgram
    {
        /// <summary>
        /// Demonstrates boxing/unboxing and issues therein.
        /// Much better and cleaner to use generics.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("***** Issues with Non-Generic Collections *****\n");
            UsePersonCollection();
            Console.WriteLine();
            UseGenericList();

            SimpleBoxUnboxOperation();
            ArrayListOfRandomObjects();
            Console.ReadLine();
        }

        #region Simple Box / Unbox
        private static void SimpleBoxUnboxOperation()
        {
            // Make a int value type.
            int myInt = 25;

            // Box the int into an object reference.
            object boxedInt = myInt;

            // Unbox in the wrong data type to trigger
            // runtime exception. 
            try
            {
                long unboxedInt = (long)boxedInt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("\nSimpleBoxUnboxOperation Exception: " + ex.Message);
            }
        }
        #endregion

        #region ArrayList box / unbox
        static void WorkWithArrayList()
        {
            // Value types are automatically boxed when
            // passed to a member requesting an object.
            ArrayList myInts = new ArrayList
            {
                10,
                20,
                35
            };

        }
        #endregion

        #region ArrayList of random objects
        static void ArrayListOfRandomObjects()
        {
            // The ArrayList can hold anything at all.
            ArrayList allMyObjects = new ArrayList
            {
                true,
                new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)),
                66,
                3.14
            };

            Console.WriteLine("ArrayList of mixed objects");
            foreach (object o in allMyObjects)
                Console.WriteLine(o.ToString());
        }
        #endregion

        #region Use custom generic class
        static void UsePersonCollection()
        {
            Console.WriteLine("***** Custom Person Collection *****\n");
            PersonCollection people = new PersonCollection();
            people.AddPerson(new Person("Homer", "Simpson", 40));
            people.AddPerson(new Person("Marge", "Simpson", 38));
            people.AddPerson(new Person("Lisa", "Simpson", 9));
            people.AddPerson(new Person("Bart", "Simpson", 7));
            people.AddPerson(new Person("Maggie", "Simpson", 2));

            // This would be a compile-time error!
            // people.AddPerson(new Car());

            foreach (Person p in people)
                Console.WriteLine(p);
        }
        #endregion

        #region Use generic list
        static void UseGenericList()
        {
            Console.WriteLine("***** Using Generics *****\n");
            // This List<> can only hold Person objects.
            List<Person> morePeople = new List<Person>
            {
                new Person("Frank", "Black", 50)
            };
            Console.WriteLine(morePeople[0]);

            // This List<> can only hold numeric data.
            List<int> moreInts = new List<int> { 10, 2 };
 
            moreInts.Sort();
            int sum = moreInts[0] + moreInts[1];

            Console.WriteLine($"Array of Ints {moreInts[0]} {moreInts[1]} sum = {sum}");

            // Compile-time error! Can't add Person object
            // to a list of ints!
            //moreInts.Add(new Person());
        }
        #endregion
    }
}
