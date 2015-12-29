using System;
using System.Collections.Generic;
using Capitalism.Departments;
using Capitalism.Interfaces;

namespace Capitalism.Models
{
    public class Company : ICompanyStructure
    {
        private string name;
        private Ceo ceo;


        public Company(string name, Ceo ceo)
        {
            this.Name = name;
            this.Ceo = ceo;
            this.Employees = new List<IEmployee>();
            this.Departments = new List<Department>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name", "The company name cannot be null or white spaces!");
                }
                name = value;
            }
        }

        public Ceo Ceo
        {
            get { return ceo; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CEO", "A comapny must have a CEO!");
                }
                ceo = value;
            }
        }

        public ICollection<Department> Departments { get; set; }
        public ICollection<IEmployee> Employees { get; set; } 
    }
}