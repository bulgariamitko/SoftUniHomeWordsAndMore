using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public abstract class Student : Person
    {
        private int studentNum;
        private double averageGrade;

        public int StudentNum
        {
            get { return studentNum; }
            set { studentNum = value; }
        }

        public double AverageGrade
        {
            get { return averageGrade; }
            set { averageGrade = value; }
        }

        protected Student(string firstName, string lastName, int age, int studentNum, double averageGrade) : base(firstName, lastName, age)
        {
            this.studentNum = studentNum;
            this.averageGrade = averageGrade;
        }
    }
}
