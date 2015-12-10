using System;
using System.Linq;
using Students_Directory;

class StudentsByAge
{
    static void Main()
    {
        // creating an instance of the StudentsDirectory class, so that we can use its IList<Student> 
        StudentsDirectory database = new StudentsDirectory();

        // running LINQ query
        var studentsByAgeQuery =
            from student in database.Students
            where student.Age >= 18 && student.Age <= 24
            select new {student.FirstName, student.LastName, student.Age}; // limiting the query to names and age

        // printing
        foreach (var student in studentsByAgeQuery)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}",
                                student.FirstName, student.LastName, student.Age);
        }
    }
}

