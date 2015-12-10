using System;
using Company.Interfaces;
using Company.Types;

namespace Company
{
    public abstract class Employee : Person, IEmployee
    {
        private double salary;
        private Department department;

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public Employee(int id, string firstName, string lastName, double salary, Department department) : base(id, firstName, lastName)
        {
            Salary = salary;
            Department = department;
        }
    }
}