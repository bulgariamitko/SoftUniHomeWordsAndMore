using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The input cannot be empty or null!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The input cannot be empty or null!");
                }
                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be less then 0 or more then 120!");
                }
                age = value;
            }
        }

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
