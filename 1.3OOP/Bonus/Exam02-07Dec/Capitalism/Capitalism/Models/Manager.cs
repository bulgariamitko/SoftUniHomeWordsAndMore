using System.Collections.Generic;
using Capitalism.Departments;
using Capitalism.Interfaces;

namespace Capitalism.Models
{
    public class Manager : Employee, IBoss
    {
        public Manager(string firstName, string lastName) : this(firstName, lastName, null)
        {
        }

        public Manager(string firstName, string lastName, Department department) : base(firstName, lastName, department)
        {
            SubordinateEmployees = new List<IEmployee>();
        }

        public ICollection<IEmployee> SubordinateEmployees { get; }
    }
}