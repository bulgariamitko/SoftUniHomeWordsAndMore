using System.Collections.Generic;
using Capitalism.Core.Interfaces;
using Capitalism.Interfaces;
using Capitalism.Models;

namespace Capitalism.Core
{
    public class CapitalismDatabase : IDatabase
    {
        public CapitalismDatabase()
        {
            Companies = new List<Company>();
            TotalSalaries = new Dictionary<IPaidPerson, decimal>();
        }

        public ICollection<Company> Companies { get; set; }
        public IDictionary<IPaidPerson, decimal> TotalSalaries { get; set; }
    }
}