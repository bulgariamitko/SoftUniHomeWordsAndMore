using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Salesmen : Employee
    {
        private const decimal SalaryFactorDefault = 0.015m;

        public Salesmen(string firstName, string lastName, IOrganizationalUnit inUnit) : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}