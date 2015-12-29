using Capitalism.Departments;
using Capitalism.Interfaces;

namespace Capitalism.Models
{
    public class Salesman : Employee
    {
        private const decimal SalesmanSalaryFactor = 1.015M;

        public Salesman(string firstName, string lastName, Department department) : base(firstName, lastName, department)
        {
        }

        public Salesman(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override decimal SalaryFactor
        {
            get { return SalesmanSalaryFactor; }
        }
    }
}