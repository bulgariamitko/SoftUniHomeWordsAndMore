﻿using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models.OrganizationalUnit
{
    public class Department : IOrganizationalUnit
    {
        private readonly IList<IOrganizationalUnit> subUnits;
        private readonly IList<IEmployee> employees;

        public string Name { get; private set; }

        public Department(string name)
        {
            this.subUnits = new List<IOrganizationalUnit>();
            this.employees = new List<IEmployee>();
            this.Name = name;
        }

        public IEnumerable<IOrganizationalUnit> SubUnits
        {
            get { return this.subUnits; }
        }

        public IEnumerable<IEmployee> Employees
        {
            get { return this.employees; }
        }
        public IEmployee Head { get; set; }

        public void AddSubUnit(IOrganizationalUnit unit)
        {
            this.subUnits.Add(unit);
        }

        public void AddEmployee(IEmployee manager)
        {
            this.employees.Add(manager);
        }

        public void RemoveEmployee(IEmployee employee)
        {
            this.employees.Remove(employee);
        }
    }
}