using System;
using System.Linq;
using Capitalism.Core.Facturies;
using Capitalism.Interfaces;
using Capitalism.Models.Interfaces;
using Capitalism.Models.OrganizationalUnit;

namespace Capitalism.Core.Commands
{
    public class CreateCompanyCommand : CommandAbstract
    {
        private string companyName;
        private string ceoFirstName;
        private string ceoLastName;
        private decimal ceoSalary;

        public CreateCompanyCommand(IDatabase db, string companyName, string ceoFirstName, string ceoLastName, decimal ceoSalary) : base(db)
        {
            this.companyName = companyName;
            this.ceoFirstName = ceoFirstName;
            this.ceoLastName = ceoLastName;
            this.ceoSalary = ceoSalary;
        }

        public override string Execute()
        {
            if (this.db.Companies.Any(c => c.Name == this.companyName))
            {
                throw new ArgumentException(String.Format("Company {0} already exists", companyName));
            }
            IOrganizationalUnit company = new Company(companyName);
            IEmployee ceo = EmployeeFactory.Create(this.ceoFirstName, this.ceoLastName, "CEO", company, this.ceoSalary);
            this.db.AddCompany(company);
            company.AddEmployee(ceo);
            company.Head = ceo;
            return "";
        }
    }
}