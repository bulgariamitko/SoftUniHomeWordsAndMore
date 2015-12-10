using System;

namespace _01Human
{
    public class Student : Human
    {
        private string facultyNum;

        public string FacultyNum
        {
            get { return facultyNum; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faculty number has less then 5 or more then 10 characters!");
                }
                facultyNum = value;
            }
        }

        public Student(string firstName, string lastName, string facultyNum) : base(firstName, lastName)
        {
            this.facultyNum = facultyNum;
        }

//        public override string ToString()
//        {
//            return String.Format("Student: {0} {1} with faculty number: {3}", FirstName, LastName, facultyNum);
//        }
    }
}