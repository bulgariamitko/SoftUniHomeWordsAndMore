using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, int studentNum, double averageGrade, string currentCourse) : base(firstName, lastName, age, studentNum, averageGrade, currentCourse)
        {

        }
    }
}
