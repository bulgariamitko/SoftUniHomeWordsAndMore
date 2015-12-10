using System.Collections.Generic;

namespace Company.Interfaces
{
    public interface IManager
    {
        List<Employee> Employees { get; set; }
    }
}