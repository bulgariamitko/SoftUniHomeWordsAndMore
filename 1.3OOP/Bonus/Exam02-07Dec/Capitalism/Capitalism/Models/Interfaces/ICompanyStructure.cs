using System.Collections.Generic;

namespace Capitalism.Interfaces
{
    public interface ICompanyStructure
    {
         string Name { get; }
        ICollection<IEmployee> Employees { get; } 
    }
}