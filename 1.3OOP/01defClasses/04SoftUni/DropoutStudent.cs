using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SoftUni
{
    public class DropoutStudent : Student
    {
        private string dropoutReason;

        public string DropoutReason
        {
            get { return dropoutReason; }
            set { dropoutReason = value; }
        }

        public DropoutStudent(string firstName, string lastName, int age, int studentNum, double averageGrade, string dropoutReason) : base(firstName, lastName, age, studentNum, averageGrade)
        {
            this.dropoutReason = dropoutReason;
        }

        public void Reapply(string firstName, string lastName, int age, int studentNum, double averageGrade,
            string dropoutReason)
        {
            Console.WriteLine("First name: {0}, Last name: {1}, Age: {2}, Student number: {3}, Averange grade: {4}, Dropreason: {5}", firstName, lastName, age, averageGrade, dropoutReason);
        }
    }
}
