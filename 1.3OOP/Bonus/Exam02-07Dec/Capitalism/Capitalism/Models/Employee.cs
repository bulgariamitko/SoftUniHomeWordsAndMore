using System;
using Capitalism.Departments;
using Capitalism.Interfaces;

namespace Capitalism
{
    public class Employee : PaidPerson, IEmployee
    {
        public Employee(string firstName, string lastName, Department department) : base(firstName, lastName)
        {
            Department = department;
        }

        public Employee(string firstName, string lastName) : this(firstName, lastName, null)
        {
        }

        public virtual decimal SalaryFactor
        {
            get { return 1; }
        }

        public Department Department { get; set; }
        
    }
}