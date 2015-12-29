using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Ceo : Employee
    {
        private const decimal SalaryFactorDefault = 0;

        public Ceo(string firstName, string lastName, IOrganizationalUnit inUnit, decimal salary) : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override decimal RecieveSalary(decimal percents, decimal ceoSalary)
        {
            TotalPaid += Salary;

            return Salary;
        }
    }
}