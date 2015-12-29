using Capitalism.Departments;

namespace Capitalism
{
    public class ChiefTelephoneOfficer : Employee
    {
        private const decimal ChiefTelephoneOfficerSalaryFactor = 0.98M;

        protected ChiefTelephoneOfficer(string firstName, string lastName, Department department) : base(firstName, lastName, department)
        {
        }

        public ChiefTelephoneOfficer(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override decimal SalaryFactor
        {
            get { return ChiefTelephoneOfficerSalaryFactor; }
        }
    }
}