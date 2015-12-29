using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Regular : Employee
    {
        private const decimal SalaryFactorDefault = 0m;

        public Regular(string firstName, string lastName, IOrganizationalUnit inUnit) : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}