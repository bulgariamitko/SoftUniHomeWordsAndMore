using System.Collections.Generic;
using Capitalism.Interfaces;

namespace Capitalism
{
    public class Ceo : PaidPerson, IBoss
    {
        public Ceo(string firstName, string lastName, decimal salary) : base(firstName, lastName)
        {
            SubordinateEmployees = new List<IEmployee>();
            Salary = salary;
        }

        public ICollection<IEmployee> SubordinateEmployees { get; }
    }
}