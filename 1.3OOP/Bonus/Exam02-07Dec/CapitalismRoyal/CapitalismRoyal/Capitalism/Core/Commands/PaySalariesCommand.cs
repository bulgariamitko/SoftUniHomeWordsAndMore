using System;
using System.Linq;
using System.Text;
using Capitalism.Interfaces;
using Capitalism.Models;
using Capitalism.Models.Interfaces;

namespace Capitalism.Core.Commands
{
    public class PaySalariesCommand : CommandAbstract
    {
        private string companyName;
        private Ceo ceo;
        private StringBuilder output;

        public PaySalariesCommand(IDatabase db, string companyName) : base(db)
        {
            this.companyName = companyName;
            this.output = new StringBuilder();
        }

        public override string Execute()
        {
            IOrganizationalUnit company = this.db.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                throw new ArgumentException(String.Format("Company {0} does not exist", companyName));
            }
            ceo = (Ceo)company.Head;
            Pay(company, 0, 0);
            return output.ToString();
        }

        private decimal Pay(IOrganizationalUnit unit, decimal paid, int depth)
        {
            foreach (var dep in unit.SubUnits)
            {
                paid += Pay(dep, 0, depth + 1);
            }
            foreach (var employee in unit.Employees)
            {
                decimal percents = (15 - depth) * 0.01m;
                paid += employee.RecieveSalary(percents, ceo.Salary);
            }
            output.Insert(0, String.Format("{0}{1} ({2:F2})\n", new string(' ', depth * 4), unit.Name, paid));
            return paid;
        }
    }
}