using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithCollections
{
    /// <summary>
    /// Introducing Collections: DictionaryEntry, ArrayList, Hashtable, Queue, and Stack.
    /// Also introducing Dictionary
    /// </summary>
    class FunWithCollectionsProgram
    {
        static void Main(string[] args)
        {


            // create an array of key,value entries
            // will use them in all of the collections
            // note the need to cast when retrieving the object

            DictionaryEntry[] entries = new DictionaryEntry[3];

            entries[0].Key = "1";
            entries[0].Value = "Hello";
            entries[1].Key = "2";
            entries[1].Value = "Goodbye";
            entries[2].Key = "3";
            entries[2].Value = "Maybe";

            // an array implements IList, but not all methods, but this will work for us just to demonstrate

            Display(entries, "Display() using DictionaryEntry array");

            // ArrayList example

            ArrayList greetingsArrayList = new ArrayList();

            greetingsArrayList.AddRange(entries);

            Display(greetingsArrayList, "Display() using ArrayList, foreach");

            Console.WriteLine("Inline using ArrayList, normal for statement, and DictionaryEntry cast");

            for (int i = 0; i < greetingsArrayList.Count; i++)
            {
                DictionaryEntry d = (DictionaryEntry)greetingsArrayList[i];
                Console.WriteLine($"{d.Key} {d.Value}");
            }

            // Hashtable example with inline initialization

            Hashtable greetingsHashtable = new Hashtable
            {
                { "1", "Hello" },
                { "2", "Goodbye" },
                { "3", "Maybe" },
                { "bye", "Say good bye"}
            }; // also use SortedList() as an alternative

            // another example for add elements using Add()

            //Hashtable greetingsHashtable = new Hashtable(); // also use SortedList() as an alternative

            //greetingsHashtable.Add("1", "Hello");
            //greetingsHashtable.Add("2", "Goodbye");
            //greetingsHashtable.Add("3", "Maybe");

            Display(greetingsHashtable, "Display using HashTable");

            // do a hash lookup

            Console.WriteLine("In greetingsHashtable, the value of {0} is {1}", 
                "2", 
                greetingsHashtable["2"]);
            // Queue example

            Queue greetingsQueue = new Queue();

            greetingsQueue.Enqueue(entries[0]);
            greetingsQueue.Enqueue(entries[1]);
            greetingsQueue.Enqueue(entries[2]);

            Display(greetingsQueue, "Display() using greetingsQueue");

            Console.WriteLine("While loop greetingsQueue count {0} using dequeue", greetingsQueue.Count);
            while (greetingsQueue.Count > 0)
            {
                DictionaryEntry d = (DictionaryEntry)greetingsQueue.Dequeue();
                Console.WriteLine("greetingsQueue dequeue {0} {1}", d.Key, d.Value);
            }

            // Stack example

            Stack greetingsStack = new Stack();

            greetingsStack.Push(entries[0]);
            greetingsStack.Push(entries[1]);
            greetingsStack.Push(entries[2]);

            Display(greetingsStack, $"Display() using greetingsStack count {greetingsStack.Count}");

            Console.WriteLine("While loop greetingsStack count {0} using pop", greetingsStack.Count);
            while (greetingsStack.Count > 0)
            {
                DictionaryEntry d = (DictionaryEntry)greetingsStack.Pop();
                Console.WriteLine("greetingsStack pop {0} {1}", d.Key, d.Value);
            }

            Console.ReadLine();
        }
        /// <summary>
        /// Display an arbitrary collection on the console
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="header">String to display on first line</param>
        static void Display(ICollection collection, string header = null)
        {
            if (header != null)
                Console.WriteLine("\n" + header + "\n");
            foreach (DictionaryEntry d in collection)
            {
                Console.WriteLine($"{d.Key} {d.Value}");
            }
        }
    }
}
