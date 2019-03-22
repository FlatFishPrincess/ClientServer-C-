﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioClassDiagram
{
    class VisualStudioClassDiagramProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("name?");
            string input = Console.ReadLine();
            Console.WriteLine(input);
            Employee instructor = new Employee { JobTitle = "Instructor", Salary = 50000, FirstName = "Michael", LastName = "Hrybyk"};
            Console.WriteLine(instructor);
            Console.ReadLine();
        }

    }

    // the rest is generated by VS Class Diagram.

    public class Person
    {
        public string FirstName;
        public string LastName;

    }

    public class Employee : Person
    {
        public string JobTitle;
        public decimal Salary;

        /// <summary>
        /// output a string value for the class
        /// </summary>
        override public string ToString()
        {
            return FirstName + " " + LastName + " " + JobTitle + " " + Salary;
        }
    }
}
