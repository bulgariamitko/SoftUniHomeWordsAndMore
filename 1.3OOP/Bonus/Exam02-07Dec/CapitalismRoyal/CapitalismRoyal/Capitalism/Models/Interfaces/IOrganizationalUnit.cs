using System.Collections.Generic;

namespace Capitalism.Models.Interfaces
{
    public interface IOrganizationalUnit
    {
        string Name { get; }
        IEnumerable<IOrganizationalUnit> SubUnits { get; }
        IEnumerable<IEmployee> Employees { get; }
        IEmployee Head { get; set; }

        void AddSubUnit(IOrganizationalUnit unit);
        void AddEmployee(IEmployee manager);
        void RemoveEmployee(IEmployee employee);
    }
}