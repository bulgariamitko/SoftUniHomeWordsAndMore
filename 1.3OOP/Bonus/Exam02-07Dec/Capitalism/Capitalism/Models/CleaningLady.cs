using Capitalism.Departments;
using Capitalism.Interfaces;

namespace Capitalism.Models
{
    public class CleaningLady : Employee
    {
        private const decimal CleaningLadySalaryFactor = 0.98M;

        public CleaningLady(string firstName, string lastName, Department department) : base(firstName, lastName, department)
        {
        }

        public CleaningLady(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override decimal SalaryFactor
        {
            get { return CleaningLadySalaryFactor; }
        }
    }
}