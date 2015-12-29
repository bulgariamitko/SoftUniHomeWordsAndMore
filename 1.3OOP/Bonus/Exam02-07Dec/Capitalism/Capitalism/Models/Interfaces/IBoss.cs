using System.Collections.Generic;

namespace Capitalism.Interfaces
{
    public interface IBoss
    {
         ICollection<IEmployee> SubordinateEmployees { get; } 
    }
}