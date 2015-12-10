using System;

namespace _04SoftUni
{
    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The age must be non negative number");
                }
                age = value;
            }
        }

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", firstName, lastName, age);
        }
    }
}
