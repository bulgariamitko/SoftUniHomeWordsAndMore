using Capitalism.Departments;
using Capitalism.Interfaces;

namespace Capitalism.Models
{
    public class Accountant : Employee
    {
        protected Accountant(string firstName, string lastName, Department department) : base(firstName, lastName, department)
        {
        }

        protected Accountant(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}