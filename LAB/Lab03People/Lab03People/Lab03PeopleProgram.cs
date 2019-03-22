using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab03People
{
    class Lab03PeopleProgram
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8},
                new Person {FirstName= "Maggie", LastName="Simpson", Age=2},
                new Person {FirstName= "Ned", LastName="Flanders", Age=42},
                new Person {FirstName= "Maude", LastName="Flanders", Age=40},
                new Person {FirstName= "Rod", LastName="Flanders", Age=12},
                new Person {FirstName= "Todd", LastName="Flanders", Age=13}
            };

            // TASK: display the list using your generic Display method

            Display("Initial array", people);

            // TASK: create a list from the array and display it

            //List<Person> peopleList = new List<Person>(people);  ==> Is this same?
            List<Person> peopleList = new List<Person>();
            //peopleList3.AddRange(people);
            peopleList.AddRange(people);

           Display("Original list", peopleList);

            // TASK: sort the list using the default comparer (last name then first name) and display it
            /*peopleList.Sort(delegate (Person a, Person b)
            {
                if(string.Compare(a.LastName, b.LastName) == 0)
                    return string.Compare(a.FirstName, b.FirstName);
                else
                    return string.Compare(a.LastName, b.LastName);
            });*/

            peopleList.Sort();
            //peopleList.Sort(new SortPeopleByLastFirstName());
            Display("Sorted by Last Name then First name using default comparer", peopleList);

            // TASK: shuffle the list (NOT THE ARRAY) and display it 
            // create a random index
            List<Person> shuffleList = new List<Person>();
            shuffleList.AddRange(people);

            //peopleList = peopleList.OrderBy(p => read.next());
            Random random = new Random();
            for(int i = 0; i< shuffleList.Count; i++)
            {
                int n = random.Next(i, shuffleList.Count());
                Person temp = shuffleList[i];
                shuffleList[i] = shuffleList[n];
                shuffleList[n] = temp;
            }
            Display("Randomized list", shuffleList);

            // TASK: sort the list by first name and display
            peopleList.Sort(new SortPeopleByFirstName());
            Display("Sorted by First Name list", peopleList);

            // TASK: create a stack and push each element onto the stack

            // create stack then push person from peopleList
            Stack<Person> stack = new Stack<Person>();
            for(int i = 0; i<peopleList.Count; i++)
            {
                stack.Push(peopleList[i]);
            }

            Person topPerson = stack.Pop();
            Person secondPerson = stack.Pop();
            stack.Push(topPerson);
            stack.Push(secondPerson);
            Display("Stack with top 2 flipped", stack);

            // TASK: sort the list by age
            peopleList.Sort(new SortPeopleByAge());

            // TASK: create a queue and add the list to the queue
            Queue<Person> peopleQ = new Queue<Person>(peopleList);

            // TASK: add two elements to the end of the queue
            peopleQ.Enqueue(new Person { FirstName = "Grandma", LastName = "Simpson", Age = 95 });
            peopleQ.Enqueue(new Person { FirstName = "Grandpa", LastName = "Simpson", Age = 100 });

            // TASK: display the queue
            Display("Age sorted Queue with Grandma and Grandpa Simpson at end", peopleQ);

            // TASK: display the number of elements in the queue
            Console.WriteLine("Number of elements in the queue: {0}",peopleQ.Count);

            // TASK: finally, dequeue each element and show that they left.
            Console.WriteLine("== DeQueue ==");
            int count = peopleQ.Count;
            for (int i = 0; i< count; i++)
            {
                Person leftPerson = peopleQ.Dequeue();
                Console.WriteLine("{0} left the queue", leftPerson);
                }
            // TASK: display the number of elements in the queue
            Console.WriteLine("Number of elements in the queue: {0}", peopleQ.Count);
            Console.ReadLine();
        }

        // Display a generic Person collection
        // use IEnumarable so we can use foreach(), but could have used a standard index
        // and a for() loop instead

        static void Display<T>(string message, T personCollection) where T : IEnumerable<Person>
        {
            Console.WriteLine("==============");
            // Your code here
            Console.WriteLine(message);
            foreach (Person p in personCollection)
                Console.WriteLine(p);
        }
    }

    // Sort classes. You will see compiler errors here until you add the code with a proper return value.

    class SortPeopleByFirstName : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            return string.Compare(a.FirstName, b.FirstName);
            // Your code here. Needs to return an int 1, 0, -1
            /*Person p1 = a as Person;
            Person p2 = b as Person;
            if (a is Person && b is Person)
                return (String.Compare((a as Person).FirstName, (b as Person).FirstName));
            else
                throw new ArgumentException("Parameter is not a Car!");*/

        }
    }

    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            /*
            if (a.Age > b.Age)
                return 1;
            if (a.Age < b.Age)
                return -1;
            else
                return 0;*/
           return a.Age - b.Age;
          }
    }


    /// <summary>
    /// Person class
    /// contains their age and first/last name
    /// 
    /// You must implement IComparable method to allow for sorting by last name then first name
    /// </summary>


    public class Person:IComparable
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

        // ToString() override to make it easy to display

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}",
                FirstName, LastName, Age);
        }


        public int CompareTo(Object obj)
        {
            /*
            if (obj == null)
                return -1;
            Person person = obj as Person;
            int value = LastName.CompareTo(person.LastName);

            if (value == 0)
                return FirstName.CompareTo(person.FirstName);
            else return value;*/
            //return Age.CompareTo(person.Age);

            Person person = obj as Person;
            int value = LastName.CompareTo(person.LastName);
            if (value == 0)
                return FirstName.CompareTo(person.FirstName);
            return value;
            /*if (LastName == person.LastName)
            {
                return FirstName.CompareTo(person.FirstName);
            }
                return LastName.CompareTo(person.FirstName);*/

        }

    }
}
