using System.Collections.Generic;
using Capitalism.Interfaces;
using Capitalism.Models;

namespace Capitalism.Core.Interfaces
{
    public interface IDatabase
    {
        ICollection<Company> Companies { get; }
        IDictionary<IPaidPerson, decimal> TotalSalaries { get; }   
    }
}