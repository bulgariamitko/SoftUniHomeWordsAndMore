using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        public bool IsOlderThan(Student student)
        {
            DateTime firstDate =
                DateTime.Parse(this.Age.Substring(this.Age.Length - 10));
            DateTime secondDate =
                DateTime.Parse(student.Age.Substring(student.Age.Length - 10));
            return firstDate > secondDate;
        }
    }
}
