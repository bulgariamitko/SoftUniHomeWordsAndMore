using Company.Types;

namespace Company
{
    public abstract class RegularEmployee : Employee
    {
        public RegularEmployee(int id, string firstName, string lastName, double salary, Department department) : base(id, firstName, lastName, salary, department)
        {

        }
    }
}