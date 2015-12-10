using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Person
{
    class Person
    {
        private string name;
        private string email;
        private int? age;

        public Person(string name, int age, string email = null)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                if (value == "")
                {
                    throw new Exception("The name have to have at least one char");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int? Age {
            get
            {
                return this.age;
            }
                set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("The age is invalid");
                }
                else
                {
                    this.age = value;
                }
            }
        }
        public string Email {
            get
            {
                return this.email;
            }
            set
            {
                if (value != null && !value.Contains('@'))
                {
                    throw new Exception("The input is not in the correct form");
                }
                else
                {
                    this.email = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Person: name: {this.name}, age: {this.age}, email: {this.email ?? "No email!"}";
        }
    }
}
