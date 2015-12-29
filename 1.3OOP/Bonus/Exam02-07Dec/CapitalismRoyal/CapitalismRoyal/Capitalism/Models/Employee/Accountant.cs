using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Accountant : Employee
    {
        private const decimal SalaryFactorDefault = 0m;

        public Accountant(string firstName, string lastName, IOrganizationalUnit inUnit) : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}