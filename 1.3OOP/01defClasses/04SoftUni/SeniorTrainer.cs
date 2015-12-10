using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {

        }

        public void DeletedCourse(string courseName)
        {
            Console.WriteLine("{0} course have been deleted!", courseName);
        }
    }
}
