using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IssuesWithNonGenericCollections
{
    public class PersonCollection : IEnumerable
    {
        // would be better to use a generic here!

        private ArrayList people = new ArrayList();

        // Cast for caller.
        public Person GetPerson(int pos)
        {
            return (Person) people[pos];
        }

        // Only insert Person types.
        public void AddPerson(Person p)
        {
            people.Add(p);
        }

        public void ClearPeople()
        {
            people.Clear();
        }

        public int Count
        {
            get { return people.Count; }
        }

        public void Sort()
        {
            people.Sort();
        }

        /// <summary>
        /// Foreach enumeration support.
        /// Just use the ArrayList enumerato
        /// </summary>
        /// <returns>IEnumerator</returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return people.GetEnumerator();
        }
    }

}
