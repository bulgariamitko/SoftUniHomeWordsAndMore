using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string firstName, string lastName, IOrganizationalUnit inUnit, decimal salaryFactor)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.InUnit = inUnit;
            this.SalaryFactor = salaryFactor;
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public IOrganizationalUnit InUnit { get; set; }
        public decimal SalaryFactor { get; protected set; }
        public decimal TotalPaid { get; set; }

        public virtual decimal RecieveSalary(decimal percents, decimal ceoSalary)
        {
            decimal toPay = ceoSalary * percents;
            toPay = toPay + toPay*SalaryFactor;
            TotalPaid += toPay;

            return toPay;
        }
    }
}