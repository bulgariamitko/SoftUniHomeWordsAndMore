using System;
using System.Linq;
using System.Text;
using Capitalism.Interfaces;
using Capitalism.Models;
using Capitalism.Models.Interfaces;

namespace Capitalism.Core.Commands
{
    public class ShowEmployiesCommand : CommandAbstract
    {
        private string companyName;
        private Ceo ceo;
        private StringBuilder output;

        public ShowEmployiesCommand(IDatabase db, string companyName) : base(db)
        {
            this.companyName = companyName;
        }

        public override string Execute()
        {
            IOrganizationalUnit company = this.db.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                throw new ArgumentException(String.Format("Company {0} does not exist", companyName));
            }
            ceo = (Ceo)company.Head;
            PrintHierarchy(company, 0);
            return "";
        }

        private void PrintHierarchy(IOrganizationalUnit unit, int depth)
        {
            Console.WriteLine("{0}({1})", new string(' ', depth * 4), unit.Name);
            foreach (IEmployee employee in unit.Employees)
            {
                Console.WriteLine("{0}{1} {2} ({3:F2})", new string(' ', depth * 4), employee.FirstName, employee.LastName, employee.TotalPaid);
            }
            foreach (IOrganizationalUnit subUnit in unit.SubUnits)
            {
                PrintHierarchy(subUnit, depth + 1);
            }
        }
    }
}