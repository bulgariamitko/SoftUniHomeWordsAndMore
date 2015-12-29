using System;
using Capitalism.Core.Facturies;
using Capitalism.Interfaces;
using Capitalism.Models.Interfaces;
using Capitalism.Models.OrganizationalUnit;

namespace Capitalism.Core.Commands
{
    public class CreateEmployeeCommand : CommandAbstract
    {
        private string firstName;
        private string lastName;
        private string position;
        private string companyName;
        private string departmentName;

        public CreateEmployeeCommand(IDatabase db, string firstName, string lastName, string position, string companyName, string departmentName = null) : base(db)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.companyName = companyName;
            this.departmentName = departmentName;
        }

        public override string Execute()
        {
            Company company = null;
            foreach (Company c in this.db.Companies)
            {
                if (c.Name == this.companyName)
                {
                    company = c;
                    break;
                }
            }
            if (company == null)
            {
                throw new ArgumentException(String.Format("Company {0} does not exist", companyName));
            }

            foreach (IEmployee allEmployee in company.AllEmployees)
            {
                if (allEmployee.FirstName == firstName && allEmployee.LastName == lastName)
                {
                    if (allEmployee.InUnit is Company)
                    {
                        throw new ArgumentException(String.Format("Employee {0} {1} already exists in {2} (no department)", firstName, lastName, companyName));
                    }
                    else
                    {
                        throw new ArgumentException(String.Format("Employee {0} {1} already exists in {2} (in department {3})", firstName, lastName, companyName, allEmployee.InUnit.Name));
                    }
                }
            }
            IOrganizationalUnit inUnit = company;
            if (departmentName != null)
            {
                foreach (IOrganizationalUnit d in company.AllDepartments)
                {
                    if (d.Name == departmentName)
                    {
                        inUnit = d;
                        break;
                    }
                }
            }
            IEmployee employee = EmployeeFactory.Create(firstName, lastName, position, inUnit);
            company.AllEmployees.Add(employee);
            inUnit.AddEmployee(employee);
            return "";
        }
    }
}