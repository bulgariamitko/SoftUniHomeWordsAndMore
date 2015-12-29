using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Manager : Employee
    {
        private const decimal SalaryFactorDefault = 0m;

        public Manager(string firstName, string lastName, IOrganizationalUnit inUnit) : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}