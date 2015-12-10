using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public abstract class Trainer : Person
    {
        protected Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("{0} course has been created", courseName);
        }
    }
}
