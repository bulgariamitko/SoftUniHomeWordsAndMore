using Company.Types;

namespace Company.Interfaces
{
    public interface IEmployee
    {
        double Salary { get; set; }
        Department Department { get; set; }
    }
}