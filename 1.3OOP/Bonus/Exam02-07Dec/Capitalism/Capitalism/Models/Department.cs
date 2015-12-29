using System;
using System.Collections.Generic;
using Capitalism.Interfaces;
using Capitalism.Models;

namespace Capitalism.Departments
{
    public class Department : ICompanyStructure
    {
        private string name;
        private Manager manager;

        public Department(string name, Manager manager)
        {
            this.Name = name;
            this.Manager = manager;
            this.Employees = new List<IEmployee>();
            SubDepartments = new List<Department>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name", "The name cannot be null, empty, whitespace only or less then 5 characters!");
                }
                name = value;
            }
        }

        public Manager Manager
        {
            get { return manager; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Manager", "The name of the manager cannot be null!");
                }
                manager = value;
            }
        }

        public ICollection<IEmployee> Employees { get; set; }
        public ICollection<Department> SubDepartments { get; set; }
    }
}