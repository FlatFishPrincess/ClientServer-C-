using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized; // for collection changed notifications

namespace FunWithObservableCollection
{
    class FunWithObservableCollectionProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Observable Collections *****\n");

            // Make a collection to observe and add a few Person objects. 
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            
            // Wire up the CollectionChanged event. This will fire when a Person is added or removed
            // not that this is the ONLY event in ObservableCollection<>

            people.CollectionChanged += PeopleCollectionChanged;

            // Now add a new item.
            people.Add(new Person("Fred", "Smith", 32));

            // Remove an item.
            people.RemoveAt(0);

            // remove the event, and now nothing will happen

            people.CollectionChanged -= PeopleCollectionChanged;

            people.Add(new Person("Jo", "Donegal", 33));

            Console.WriteLine("Showing all people in ObservableCollection with event turned off and Jo added");
            foreach (Person p in people)
                Console.WriteLine(p);

            Console.ReadLine();
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
                return string.Format("Name: {0} {1}, Age: {2}",
                  FirstName, LastName, Age);
            }
        }

        #region CollectionChanged event handler
        static void PeopleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event? It can be Add, Remove, Move, Replace, Reset


            Console.WriteLine($"Action for this event: {e.Action}");

            // a Person was removed, check for OldItems in the event

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

            // a Person was added, check for NewItems in the event

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p);
                }
            }
        } 
        #endregion
    }
}
