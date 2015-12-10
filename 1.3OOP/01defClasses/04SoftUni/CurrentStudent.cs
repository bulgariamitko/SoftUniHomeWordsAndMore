using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public class CurrentStudent : Student
    {
        private string currentCourse;

        public string CurrentCourse
        {
            get { return currentCourse; }
            set { currentCourse = value; }
        }

        public CurrentStudent(string firstName, string lastName, int age, int studentNum, double averageGrade, string currentCourse) : base(firstName, lastName, age, studentNum, averageGrade)
        {
            this.currentCourse = currentCourse;
        }
    }
}
