using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    class SULSTest
    {
        static void Main(string[] args)
        {
            Junior jt = new Junior("Ivan", "Ivanov", 22);
            SeniorTrainer st = new SeniorTrainer("Georgi", "Georgiev", 25);
            DropoutStudent ds = new DropoutStudent("Dimitar", "Dimitrov", 40, 456456, 3.55, "OOP");
            OnsiteStudent oss = new OnsiteStudent("Pesho", "Petrov", 12, 455454, 4.44, "OOP", 45);
            OnlineStudent oos = new OnlineStudent("Dimo", "Padalski", 24, 454545, 5.55, "OOP");
            GraduateStudent gs = new GraduateStudent("Stamat", "Petrov", 26, 54455454, 5.77);

            List<Person> students = new List<Person>() { jt, st, ds, oos, oss, gs };

            var currentStudents =
                students.OfType<CurrentStudent>().OrderBy(x => x.AverageGrade);

            foreach (var currentStudent in currentStudents)
            {
                Console.WriteLine("Student: {0} {1}, Age: {2}, StudentNumber: {3}, AverageGrade: {4}", currentStudent.FirstName, currentStudent.LastName, currentStudent.Age, currentStudent.StudentNum, currentStudent.AverageGrade);
            }
        }
    }
}
