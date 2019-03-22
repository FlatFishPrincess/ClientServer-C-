using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentTestScores
{
    class StudentTestScoresProgram
    {
        // Create student data source: student name, and list of test scores

        static Student[] students = new Student[]
        {
            new Student("Svetlana",  97, 92, 81, 60 ),
            new Student("Claire",  75, 84, 91, 39),
            new Student("Sven", 88, 94, 65, 91 ),
            new Student("Cesar", 97, 89, 85, 82  ),
            new Student("Debra", 35, 72, 91, 70  ),
            new Student("Fadi",  86, 86, 90, 94 ),
            new Student("Hanying", 93, 92, 80, 87 ),
            new Student("Hugo", 92, 90, 83, 78 ),
            new Student("Lance", 68, 79, 88, 92 ),
            new Student("Terry", 99, 82, 81, 79 ),
            new Student("Eugene", 75, 85, 91, 60 ),
            new Student()
            {
                Name = "Michael",
                Scores = new int[] {94, 92, 91, 91 }
            }

        };

        // test score list: only used by TestScores() sample method

        static List<int> testScores = new List<int>() { 95, 35, 65, 25, 100, 91, 60, 72, 55, 80, 77 };

        static void Main(string[] args)
        {
            TestScores();  // sample only

            StudentScoresBasic();

            StudentScoresOrderAndGroup();

            StudentScoreStats();

            Console.ReadLine();
        }

        // TestScores()
        // three queries and their output

        static void TestScores()
        {
            // select all scores and simply output them

            var scoresQuery1 =
                from score in testScores
                orderby score
                select score;

            // using LINQ methods and lambdas
            // var scoresQuery1 = testScores.OrderBy(s => s);
            var scoreLamda1 = testScores.OrderBy(s => s);
            foreach (var s in scoreLamda1)
                Console.WriteLine(s);
            Console.WriteLine("== Test Scores ==");
            foreach (var s in scoresQuery1)
                Console.WriteLine(s);

            // similar, but only choose scores greater than some number

            const int cutoffScore = 75;

            var scoresQuery2 =
                from score in testScores
                where score > cutoffScore
                select score;

            var scoreLamda = testScores.Where(s => s > cutoffScore);
            // using LINQ methods and lambdas
            // var scoresQuery2 = testScores.Where(s => s > cutoffScore);

            Console.WriteLine("== Test Scores > {0} ==", cutoffScore);
            foreach (var s in scoresQuery2)
                Console.WriteLine(s);

            // similar, only showing above the midpoint.
            // note that we could have used a let statement here as well

            int midpointFixed = (testScores.Min() + testScores.Max()) / 2;

            var scoresQuery3 =
                from score in testScores
                let midpoint = (testScores.Min() + testScores.Max()) / 2
                where score > midpoint
                orderby score
                select score;

            // using LINQ methods and lambdas
            // var scoresQuery3 = testScores.Where(s => s > midpointFixed).OrderBy(s => s);


            Console.WriteLine("== Test Scores above midpoint {0} ==", midpointFixed);
            foreach (var s in scoresQuery3)
                Console.WriteLine(s);

        }

        // StudentScoresBasic()
        // Query1: simply list all students and their scores
        // Query2: list all students whose first score is below 90 and output them in order

        static void StudentScoresBasic()
        {
            // Select all students and output result
            // Query1
            var studentQuery =
                from student in students
                select student;

            Console.WriteLine("== Student Scores: All count {0} ==", studentQuery.Count());
            foreach (var s in studentQuery)
                Console.WriteLine(s);

            var query2 = students.Where(s => s.Scores[0] < 90).OrderBy(s => s.Name);
            Console.WriteLine("lamda");
            foreach (var s in query2)
                Console.WriteLine(s);
            // Query2
            var studentQuery2 =
               from student in students
               where student.Scores[0] < 90
               orderby student.Name
               select student;

            Console.WriteLine("== Student Scores:first score< 90, Count {0}==", studentQuery2.Count());
            foreach (var s in studentQuery2)
                Console.WriteLine(s);
        }

        // StudentScoresOrderAndGroup()
        // Query1: group students by first letter of name, UNORDERED, then output by key then name
        // Query2: group students by first letter of name, ORDERED DESCENDING, then output by key then name
        static void StudentScoresOrderAndGroup()
        {

            //Group students by the second letter of their name and order
            //DESCENDING by this letter
            //• see lecture notes for hints
            //• Use Linq group by

            // Query1
            var studentQuery1 =
                from student in students
                group student by student.Name[0] into studentGroup
                select studentGroup;
            var query1 = students.GroupBy(s => s.Name[0]).OrderBy(s => s.Key);
            Console.WriteLine(query1);
            foreach (var studentGroup in query1)
            {
                Console.WriteLine(studentGroup.Key);
                foreach(var student in studentGroup)
                {
                    Console.WriteLine(" " + student.Name);
                }
            }

           // Console.WriteLine("== Students Group:by first letter of name, Count {0}==", studentQuery1.Count());
            foreach (var studentGroup in studentQuery1)
            {
                Console.WriteLine(studentGroup.Key);
                foreach(Student student in studentGroup)
                {
                    Console.WriteLine(" " + student.Name);
                }
            }

            var query2 = students.GroupBy(s => s.Name[1]).OrderByDescending(s => s.Key);
            var query2Sql = from student in students
                            group student by student.Name[1] into studentGroup
                            orderby studentGroup descending
                            select studentGroup;
                             
            foreach(var studentGroup in query2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach(var student in studentGroup)
                {
                    Console.WriteLine(student.Name);
                }
            }

            // Query2           
            var studentQuery2 =
                from student in students
                group student by student.Name[0] into studentGroup
                orderby studentGroup.Key descending
                select studentGroup;
            Console.WriteLine("== Students Group:by first letter of name, Count {0}==", studentQuery2.Count());
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine(" " + student.Name);
                }
            }
        }

        // StudentScoreStats()
        // Query: result set should include name, student score average, student max and min score
        // Output the result set
        // Then show the overall class average and average of max and min scores

        static void StudentScoreStats()
        {
            //Create new datasource(query) projecting name, student test score
            //average(of their 4 scores), and the highest and lowest mark
           
            // group by name to get name as a key
            var averageQuery =
                from student in students
                group student by student.Name into studentGroup
                select new
                {
                    Name = studentGroup.Key,
                    AverageScore = studentGroup.Average(s => s.Scores.Average()),
                    MaxScore = studentGroup.Max(s => s.Scores.Max()),
                    MinScore = studentGroup.Min(s => s.Scores.Min())
                };

            var querySql = from student in students
                           select new
                           {
                               Name = student.Name,
                               AverageScore = student.Scores.Average(),
                               MaxScore = student.Scores.Max(),
                               MinScore = student.Scores.Min()
                           };

            var query1 = students.Select(s => 
                            new { Name = s.Name, 
                                  Average = s.Scores.Average(),
                                  MaxScore = s.Scores.Max(),
                                  MinScore = s.Scores.Min() });
           // Console.WriteLine(query1);
          foreach(var student in query1)
            {
                Console.WriteLine("Name: {0}, Average Score: {1}, Max Score: {2}, Min Score = {3}",
                                    student.Name, student.Average, student.MaxScore, student.MinScore);
            }


            // Display stats
            Console.WriteLine("== Students Score Stats, Count {0} ==", averageQuery.Count());
            foreach (var student in averageQuery)
            {
                Console.WriteLine("Name: {0}: AverageScore = {1}, Max Score = {2}, Min Score = {3}",
                    student.Name,
                    student.AverageScore,
                    student.MaxScore,
                    student.MinScore);
            }

            // get average of average, max and min score 
            Console.WriteLine("All students overall average = {0:F1}", averageQuery.Average(p => p.AverageScore));
            Console.WriteLine("All students average of highest = {0:F1}", averageQuery.Average(p => p.MaxScore));
            Console.WriteLine("All students average of loweste = {0:F1}", averageQuery.Average(p => p.MinScore));
        }
    }
    // Student class

    public class Student
    {
        public string Name { get; set; }  // student name
        public int[] Scores { get; set; } // test scores

        // constructor - just need 4 test scores for this example

        public Student() { }

        public Student(string name, int s1, int s2, int s3, int s4)
        {
            Name = name;
            Scores = new int[4] { s1, s2, s3, s4 };
        }

        // ToString() override allows for easier display of student and their scores

        override public string ToString()
        {
            return $"Name: {Name} Scores: {Scores[0]}, {Scores[1]}, {Scores[2]}, {Scores[3]}";
        }
    }

}
