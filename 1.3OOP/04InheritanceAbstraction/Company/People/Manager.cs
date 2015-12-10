using System.Collections.Generic;
using System.Linq;
using Company.Interfaces;
using Company.Types;

namespace Company
{
    public class Manager : Employee, IManager
    {
        private List<Employee> employees;

        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public Manager(int id, string firstName, string lastName, double salary, Department department, params Employee[] employees) : base(id, firstName, lastName, salary, department)
        {
            Employees = employees.ToList();
        }

        public override string ToString()
        {
            return string.Format("Manager: {0} {1}, Department: {2}, Employee: {3}", FirstName, LastName, Department,
                string.Join(", ", employees.Select(x => x.FirstName)));
        }
    }
}