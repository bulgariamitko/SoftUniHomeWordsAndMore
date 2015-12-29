using Capitalism.Departments;

namespace Capitalism.Interfaces
{
    public interface IEmployee : IPaidPerson
    {
        Department Department { get; set; }
        decimal SalaryFactor { get; }
    }
}